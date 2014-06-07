using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public DataGridView mygridview;
        const string dllfilename = @"D:\admin\desktop\DragonNest\Tools\dntfile\Debug\dnthandler.dll";
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadDntFile(string filename);
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SaveDntFile(string filename);
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRow();
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCol();
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetTitle(int col);
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetValue(int row, int col);
        [DllImport(dllfilename, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetValue(int row, int col, string value);

        Dictionary<string, string> namesdict;
        public Form1()
        {
            InitializeComponent();
            mygridview = dataGridView1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            namesdict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader("items.txt");
            while (!sr.EndOfStream)
            {
                string id = sr.ReadLine();
                string name = sr.ReadLine();
                namesdict.Add(id, name);
            }
            sr.Close();
        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            int colindex = e.ColumnIndex;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;
            dataGridView1.Rows[rowindex].Cells[colindex].Style = style;
            if (dataGridView1.Rows[rowindex].Cells[colindex].Value != null && !string.IsNullOrEmpty(dataGridView1.Rows[rowindex].Cells[colindex].Value.ToString()))
            {
                SetValue(rowindex, colindex, dataGridView1.Rows[rowindex].Cells[colindex].Value.ToString());
            }
          
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            LoadDntFile(file);
            int  row=GetRow();
            int col=GetCol();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            int namecolumn = -1;
            int nameidparam=-1;
            for (int i = 0; i < col;i++ )
            {
                IntPtr intPtr=GetTitle(i);
                string title = Marshal.PtrToStringAnsi(intPtr);
                if (title == "_NameID")
                {
                    namecolumn = i;
                }
                if (title == "_NameIDParam")
                {
                    nameidparam = i;
                }
                dataGridView1.Columns.Add(title, title);
                dataGridView1.Columns[dataGridView1.Columns.Count-1].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < row;i++ )
            {
                DataGridViewRow newrow = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for(int j=0;j<col;j++)
                {
                    IntPtr intPtr = GetValue(i,j);
                    string cellvalue = Marshal.PtrToStringAnsi(intPtr);
                    newrow.Cells[j].Value=cellvalue;
                }
                string n="";
                if (namecolumn >= 0)
                {
                    bool hasvalue = namesdict.TryGetValue(newrow.Cells[namecolumn].Value.ToString(), out n);
                    if (nameidparam >= 0)
                    {
                        if(newrow.Cells[nameidparam].Value!=null)
                        {
                            string namparamstr = newrow.Cells[nameidparam].Value.ToString();
                            if (!string.IsNullOrEmpty(namparamstr))
                            {


                                string[] nameparams = namparamstr.Split(',');
                                string[] namevalues = new string[nameparams.Length];
                                for (int k = 0; k < nameparams.Length; k++)
                                {

                                    if (nameparams[k].IndexOf("{")>=0)
                                    {
                                        namevalues[k] = nameparams[k].Substring(1, nameparams[k].Length - 2);
                                    }
                                    else
                                    {
                                        namevalues[k] = nameparams[k];
                                    }
                                      
                                    
                                       
                                    
                                    
                                    namesdict.TryGetValue(namevalues[k], out  namevalues[k]);
                                }
                                n = string.Format(n, namevalues);
                            }
                        }
                       
                    }
                }

                newrow.HeaderCell.Value = n;
                dataGridView1.Rows.Add(newrow);
            }
                MessageBox.Show(string.Format("Load {0} Cols, {1} Rows", col, row));
        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string file = saveFileDialog1.FileName;
            SaveDntFile(file);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            int colindex = e.ColumnIndex;
        }

        private void 搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search(this);
            s.Show();
        }
    }
}
