using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PlantsVsZombiesTool;
using hook1;
namespace 无限闪避
{
    public partial class 自定义飞行点 : Form
    {
        Nest[] movenest;
        int movenestnum;
        int baseadr = 0, xp = 0, yp = 0;
        string processname = "";
        int save = 0;
        int isinit = 1;
        int selectindex = -1;
        hook1.无限闪避 ccf;
        ToolStripMenuItem []nestitems;
        public 自定义飞行点()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void 自定义飞行点_Load(object sender, EventArgs e)
        {
            
            button3.Enabled = false;
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip=contextMenuStrip1;
            dataGridView1.Rows.CollectionChanged+= new CollectionChangeEventHandler(Rows_CollectionChanged);
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ;
            StreamReader infile = new StreamReader("Set.ini", Encoding.GetEncoding("gb2312"));
            string tempstring = infile.ReadLine();          
            tempstring = infile.ReadLine();           
            tempstring = infile.ReadLine();       
            tempstring = infile.ReadLine();
            int nestnum = Convert.ToInt32(tempstring.Substring(tempstring.IndexOf("=") + 1));
            movenestnum = nestnum;
            movenest = new Nest[nestnum];
            nestitems = new ToolStripMenuItem[nestnum];

            for (int j = 0; j < nestnum; j++)
            {
                tempstring = infile.ReadLine();
                string nestname = tempstring.Substring(tempstring.IndexOf("=") + 1);
                tempstring = infile.ReadLine();
                int nestmovenum = Convert.ToInt32(tempstring.Substring(tempstring.IndexOf("=") + 1));
                movenest[j] = new Nest(nestname, nestmovenum);             
                movenest[j].ReadNest("Locate.txt");
                comboBox1.Items.Add(nestname);
                nestitems[j] = new ToolStripMenuItem(nestname);
             
                删除巢穴ToolStripMenuItem.DropDownItems.Add(nestitems[j]);
                nestitems[j].Click+=new EventHandler(自定义飞行点_Click);

            }
            infile.Close();
            dataGridView1.Columns[0].HeaderText = "传送点名称";
            dataGridView1.Columns[1].HeaderText = "X坐标";
            dataGridView1.Columns[0].ValueType = typeof(string);
            dataGridView1.Columns[1].ValueType = typeof(short);
            dataGridView1.Columns[2].ValueType = typeof(short);
            dataGridView1.Columns[2].HeaderText = "Y坐标";
            for (int i = 0; i < movenest[0].movepointnum; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value= movenest[0].movepointname[i];
                dataGridView1.Rows[i].Cells[1].Value = movenest[0].movex[i];
                dataGridView1.Rows[i].Cells[2].Value = movenest[0].movey[i];
            }
            selectindex = 0;
            comboBox1.SelectedIndex = 0;
        }

        void 自定义飞行点_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < movenestnum; i++)
            {
                if (sender.ToString() == movenest[i].nestname)
                {
                    if (MessageBox.Show("是否删除副本" + movenest[i].nestname, "注意",MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    int k = 0;
                    Nest[] tmpnest = new Nest[movenestnum];
                    for (int l = 0; l < movenestnum; l++)
                    {
                      
                        tmpnest[l] = new Nest(movenest[l]);
                    }
                    movenest = null;
                    movenestnum--;
                    movenest = new Nest[movenestnum];
                    k = 0;
                    for (int l = 0; l < movenestnum; l++)
                    {
                        if (k == i)
                        {
                            k++;
                        }
                        movenest[l] = new Nest(tmpnest[k]);
                        k++;
                    }
                    break;
                }
            }
            comboBox1.Items.Clear();
            删除巢穴ToolStripMenuItem.DropDownItems.Clear();
            nestitems = null;
            nestitems = new ToolStripMenuItem[movenestnum];
            for (int i = 0; i < movenestnum; i++)
            {
                comboBox1.Items.Add(movenest[i].nestname);
                nestitems[i] = new ToolStripMenuItem(movenest[i].nestname);

                删除巢穴ToolStripMenuItem.DropDownItems.Add(nestitems[i]);
                nestitems[i].Click += new EventHandler(自定义飞行点_Click);
            }
            comboBox1.SelectedIndex = movenestnum - 1;
            dataGridView1.Rows.Clear();
            save = 0;
            isinit = 1;
            button3.Enabled =false;
            string[] set = new string[3];

            StreamReader sr = new StreamReader("Set.ini");
            for (int i = 0; i < 3; i++)
                set[i] = sr.ReadLine();
            sr.Close();
            FileStream thefile = new FileStream("Set.ini", FileMode.Create);
            StreamWriter sw = new StreamWriter(thefile, Encoding.GetEncoding("gb2312"));
            for (int i = 0; i < 3; i++)
                sw.WriteLine(set[i]);
            sw.WriteLine("副本个数=" + movenestnum);
            for (int i = 0; i < movenestnum; i++)
            {
                sw.WriteLine("副本" + (i + 1) + "名称=" + movenest[i].nestname);
                sw.WriteLine("副本" + (i + 1) + "传送点个数=" + movenest[i].movepointnum);
            }
            sw.Close();
            thefile = null;
            thefile = new FileStream("Locate.txt", FileMode.Create);
            sw = new StreamWriter(thefile, Encoding.GetEncoding("gb2312"));
            for (int i = 0; i < movenestnum; i++)
            {
                sw.WriteLine("#" + movenest[i].nestname);
                for (int j = 0; j < movenest[i].movepointnum; j++)
                {
                    sw.WriteLine(movenest[i].movepointname[j]);
                    sw.WriteLine("movx =" + movenest[i].movex[j]);
                    sw.WriteLine("movy =" + movenest[i].movey[j]);
                }
            }
            sw.Close();

        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isinit == 1)
                return;
            if (dataGridView1.ReadOnly == false)
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.SkyBlue;
                save = 1;
                button3.Enabled = true;
            }
        }

        

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

      
        

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int x = e.ColumnIndex;
            int y = e.RowIndex;    
            MessageBox.Show( dataGridView1.Rows[y].Cells[0].Value.ToString()+"的"+ dataGridView1.Columns[x].HeaderText+"坐标越界（-32767，32767）","注意",MessageBoxButtons.OK);
            
        }

        void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
           // MessageBox.Show("asd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isinit = 0;
            dataGridView1.ReadOnly = false;
            dataGridView1.Rows.Add();
            dataGridView1[0, dataGridView1.Rows.Count - 1].Value = "传送点"+dataGridView1.Rows.Count;
            dataGridView1.Focus();
            dataGridView1.CurrentCell= dataGridView1[0, dataGridView1.Rows.Count - 1];
            
            int tmp=0,tempx = 0, tempy = 0;
            tmp = Helper.ReadMemoryValue32(baseadr, processname);
            tempx = Helper.ReadMemoryValue16(tmp + xp, processname);
            tempy = Helper.ReadMemoryValue16(tmp + yp, processname);
            if (tempx != 0 || tempy != 0)
            {
                if (MessageBox.Show("是否使用当前坐标", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = tempx;
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tempy;
                }
            }
            
           
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中删除项");
                return;
            }
            if (MessageBox.Show("确定要删除选中项吗？", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
               
                    while (dataGridView1.SelectedRows.Count > 0)
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    save = 1;
                    button3.Enabled = true;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input inputbox = new Input();
            inputbox.ShowDialog();
            string name = "";
            if (inputbox.DialogResult == DialogResult.OK)
            {
                name = inputbox.name;
                if (name == "")
                {
                    MessageBox.Show("未创建副本（名字为空）");
                    return;
                }
                for (int i = 0; i < movenestnum; i++)
                {
                    if (name == comboBox1.Items[i].ToString())
                    {
                        MessageBox.Show("该副本已存在");
                        comboBox1.SelectedIndex = i;
                        selectindex = i;
                        dataGridView1.Rows.Clear();
                        for (int j= 0; j < movenest[selectindex].movepointnum; j++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[j].Cells[0].Value = movenest[selectindex].movepointname[j];
                            dataGridView1.Rows[j].Cells[1].Value = movenest[selectindex].movex[j];
                            dataGridView1.Rows[j].Cells[2].Value = movenest[selectindex].movey[j];
                        }
                        button3.Enabled = false;
                        dataGridView1.ReadOnly = true;
                        return;
                    }
                }
                Nest[] tmpnest = new Nest[movenestnum];
                for (int i = 0; i < movenestnum; i++)
                    tmpnest[i] = new Nest(movenest[i]);
                movenest = null;
                movenestnum++;
                movenest = new Nest[movenestnum];

                for (int j = 0; j < movenestnum-1; j++)
                   movenest [j] = new Nest(tmpnest[j]);
                movenest[movenestnum - 1] = new Nest(name, 0);
                comboBox1.Items.Clear();

                删除巢穴ToolStripMenuItem.DropDownItems.Clear();
                nestitems = null;
                nestitems = new ToolStripMenuItem[movenestnum];
             

                for (int i = 0; i < movenestnum; i++)
                {
                    comboBox1.Items.Add(movenest[i].nestname);
                    nestitems[i] = new ToolStripMenuItem(movenest[i].nestname);

                    删除巢穴ToolStripMenuItem.DropDownItems.Add(nestitems[i]);
                    nestitems[i].Click += new EventHandler(自定义飞行点_Click);
                }
                comboBox1.SelectedIndex = movenestnum - 1;
                dataGridView1.Rows.Clear();
                save = 0;
                isinit = 1;
                button3.Enabled = false;
            }
        }

       public  void init(int b, int x,int y,string s,hook1.无限闪避 cf)
        {
            baseadr = b;
            xp = x;
            yp = y;
            processname = s;
            ccf = cf;
        }

       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (comboBox1.SelectedIndex == selectindex)
               return;
           if (save == 1)
           {
               if (MessageBox.Show("未保存是否继续", "注意", MessageBoxButtons.YesNo) == DialogResult.No)
               {
                   comboBox1.SelectedIndex=selectindex;
                   return;
               }
           }
           save = 0;
           isinit = 1;
           selectindex = comboBox1.SelectedIndex;
           dataGridView1.Rows.Clear();
           for (int i = 0; i < movenest[selectindex].movepointnum; i++)
           {
               dataGridView1.Rows.Add();
               dataGridView1.Rows[i].Cells[0].Value = movenest[selectindex].movepointname[i];
               dataGridView1.Rows[i].Cells[1].Value = movenest[selectindex].movex[i];
               dataGridView1.Rows[i].Cells[2].Value = movenest[selectindex].movey[i];
           }
           button3.Enabled = false;
           dataGridView1.ReadOnly = true;
       }

       private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
       {
           if( dataGridView1.SelectedCells.Count>1)
           {
               MessageBox.Show("只能修改一个值","注意");
               return;
           }
           dataGridView1.ReadOnly = false;
           dataGridView1.Focus();

           dataGridView1.CurrentCell = dataGridView1.SelectedCells[0];
           dataGridView1.BeginEdit(true);
           isinit = 0;
          
       }

       private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
       {
           isinit = 0;
           dataGridView1.ReadOnly = false;
           dataGridView1.Rows.Add();
           dataGridView1[0, dataGridView1.Rows.Count - 1].Value = "传送点" + dataGridView1.Rows.Count;
           dataGridView1.Focus();
           dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.Rows.Count - 1];

           int tmp = 0, tempx = 0, tempy = 0;
           tmp = Helper.ReadMemoryValue32(baseadr, processname);
           tempx = Helper.ReadMemoryValue16(tmp + xp, processname);
           tempy = Helper.ReadMemoryValue16(tmp + yp, processname);
           if (tempx != 0 || tempy != 0)
           {
               if (MessageBox.Show("是否使用当前坐标", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                   dataGridView1[1, dataGridView1.Rows.Count - 1].Value = tempx;
                   dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tempy;
               }
           }
       }

       private void button3_Click(object sender, EventArgs e)
       {
           if (save == 0)
               return;
           DataTable ds= new DataTable();
       
           for (int i = 0; i < dataGridView1.Columns.Count; i++)
           {
               ds.Columns.Add(dataGridView1.Columns[i].HeaderText,dataGridView1.Columns[i].ValueType);           
           }
           for (int i = 0; i < dataGridView1.Rows.Count; i++)
           {
               short rx = 0, ry = 0;
               if (dataGridView1[1, i].Value == null || dataGridView1[2, i].Value == null||dataGridView1[1, i].Value.ToString() =="" || dataGridView1[2, i].Value.ToString() == "")
               {
                   if (MessageBox.Show(dataGridView1[0, i].Value.ToString() + "的" +  "X坐标或Y坐标为空\n是否要忽略该传送点", "注意",MessageBoxButtons.YesNo) == DialogResult.Yes)
                   {
                       continue;
                   }
               }
               else
               {
                   rx = Convert.ToInt16( dataGridView1[1, i].Value.ToString());
                   ry =Convert.ToInt16(dataGridView1[2, i].Value.ToString());
               }
               ds.Rows.Add(dataGridView1[0,i].Value, rx,ry);
           }
           movenest[selectindex].Reset(ds);
           string[] set = new string[3];
           StreamReader sr = new StreamReader("Set.ini");
           for (int i = 0; i < 3; i++)
               set[i]=sr.ReadLine();
           sr.Close();
           FileStream thefile = new FileStream("Set.ini", FileMode.Create);
           StreamWriter sw = new StreamWriter(thefile, Encoding.GetEncoding("gb2312"));
           for (int i = 0; i < 3; i++)
               sw.WriteLine(set[i]);
           sw.WriteLine("副本个数="+movenestnum);
           for (int i = 0; i < movenestnum; i++)
           {
               sw.WriteLine("副本"+(i+1)+"名称=" + movenest[i].nestname);
               sw.WriteLine("副本" + (i + 1) + "传送点个数=" + movenest[i].movepointnum);
           }
           sw.Close();
           thefile = null;
           thefile = new FileStream("Locate.txt", FileMode.Create);
           sw = new StreamWriter(thefile, Encoding.GetEncoding("gb2312"));
           for (int i = 0; i < movenestnum; i++)
           {
               sw.WriteLine("#" + movenest[i].nestname);
               for (int j = 0; j < movenest[i].movepointnum; j++)
               {
                   sw.WriteLine(movenest[i].movepointname[j]);
                   sw.WriteLine("movx =" + movenest[i].movex[j]);
                   sw.WriteLine("movy =" + movenest[i].movey[j]);
               }
           }
           sw.Close();
           isinit = 1;
           dataGridView1.Rows.Clear();
           for (int i = 0; i < movenest[selectindex].movepointnum; i++)
           {
               dataGridView1.Rows.Add();
               dataGridView1.Rows[i].Cells[0].Value = movenest[selectindex].movepointname[i];
               dataGridView1.Rows[i].Cells[1].Value = movenest[selectindex].movex[i];
               dataGridView1.Rows[i].Cells[2].Value = movenest[selectindex].movey[i];
           }
        
           dataGridView1.ReadOnly = true;
           save = 2;
           button3.Enabled = false;
       }
    }
}
