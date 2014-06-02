using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PlantsVsZombiesTool;
namespace readname
{
    public partial class 基址查找 : Form
    {
        delegate int getdelga();
        
        int baseadr = 0x011be618, job = 0xb54, zhanname = 0x2158, muname = 0x2150, faname = 0x2180, gongname = 0x2168;
        int hProcess;
        int c1f = 0, c2f = 0;
        int curspeeds = 336;
        int dddddddx = 20;
        public 基址查找()
        {
            InitializeComponent();
        }

        public string GetPname(int jbk)
        {
            string name="";
            byte[] namedata = new byte[100];
            int nemelen = 0;
            int tp=Helper.ReadMemoryValue32(baseadr,"dragonnest");
            int munam = 0;
            if (jbk == 1)
                munam = zhanname;
            if (jbk == 2)
                munam = muname;
            if (jbk == 3)
                munam = faname;
            if (jbk == 4)
                munam = gongname;
            for (int i = 0; ; i++)
            {
                namedata[i] =(byte)Helper.ReadMemoryValue16(tp+munam+i, "dragonnest");
                if ( i % 2 == 1)
                {
                    if (namedata[i] == 0 && namedata[i - 1] == 0)
                        break;
                    nemelen++;
                }
               
            }
            byte[] nn = new byte[2 * nemelen + 2];
            for(int i=0;i<2 * nemelen + 2;i++)
            {
                nn[i] = namedata[i];
            }
            namedata = Encoding.Unicode.GetBytes("什么情况没名字了");
            name =Encoding.Unicode.GetString(nn);
            return name;
        }

        public string GetJob()
        {
            string name = "";
            byte[] namedata = new byte[100];
            int nemelen = 0;
            int tp = Helper.ReadMemoryValue32(baseadr, "dragonnest");
            for (int i = 0; ; i++)
            {
                namedata[i] = (byte)Helper.ReadMemoryValue16(tp + job + i, "dragonnest");
                if (i % 2 == 1)
                {
                    if (namedata[i] == 0 && namedata[i - 1] == 0)
                        break;
                    nemelen++;
                }

            }
            byte[] nn = new byte[2 * nemelen + 2];
            for (int i = 0; i < 2 * nemelen + 2; i++)
            {
                nn[i] = namedata[i];
            }
            name = Encoding.Unicode.GetString(nn);
            return name;
        }

        public void GetSpeed()
        {
            for (int i = 0; i < 0x7fff; i++)
            {
                if(c1f==0)
                label1.Text = "正在查找" +  i.ToString("X")+ "个内存偏移";
                int tp = Helper.ReadMemoryValue32(baseadr, hProcess);
                int data1 = Helper.ReadMemoryValue32(tp + i, hProcess);
                int speed = Helper.ReadMemoryValue32(data1 + 8, hProcess);
                if ((speed ^ data1) - curspeeds > -dddddddx && (speed ^ data1) - curspeeds < dddddddx)
                {
                    listBox1.Items.Add(i.ToString("X"));
                    listBox3.Items.Add(i.ToString());
                }
            }
            label1.Text = "查找完毕共" + listBox1.Items.Count + "个符合条件";
            c1f = 1;
            button1.Enabled = true;
        }

        public void GetSpeed2()
        {
            for (int i = 0x8000; i < 0x10000; i++)
            {
               // label1.Text = "正在查找" + i.ToString("X") + "个内存偏移";
                int tp = Helper.ReadMemoryValue32(baseadr, hProcess);
                int data1 = Helper.ReadMemoryValue32(tp + i, hProcess);
                int speed = Helper.ReadMemoryValue32(data1 + 8, hProcess);
                if ((speed ^ data1) - curspeeds > -dddddddx && (speed ^ data1) - curspeeds < dddddddx)
                {
                    listBox1.Items.Add(i.ToString("X"));
                    listBox3.Items.Add(i.ToString());
                }
              
            }
            label1.Text = "查找完毕共" + listBox1.Items.Count + "个符合条件";
            c1f = 1;
            button1.Enabled = true;
        }
        int distance = 5;
        public void GetLocate()
        {
            for (int i = 0; i < 0x7fff; i++)
            {
                if(c2f==0)
                label2.Text = "正在查找" + i.ToString("X") + "个内存偏移";

               // float aaaaa = Helper.ReadMemoryFloat16(0x0F77FFC8, hProcess);
                int tp = Helper.ReadMemoryValue32(baseadr, hProcess);
                float x = Helper.ReadMemoryFloat16(tp + i, hProcess);
                float y = Helper.ReadMemoryFloat16(tp + i, hProcess);
                float z = Helper.ReadMemoryFloat16(tp + i, hProcess);
                float real_x = Convert.ToSingle(textBox2.Text);
                float real_y = Convert.ToSingle(textBox3.Text);
                float real_z = Convert.ToSingle(textBox4.Text);
                //if (x >-15600 && x < -15000 && y > 17000&& y < 18000)
                //{
                //    listBox2.Items.Add(i.ToString("X"));
                //    listBox4.Items.Add(i.ToString());
                   
                //}
                if(Math.Abs( x-real_x)<distance)
                {
                    listBox2.Items.Add(i.ToString("X") + " x" + ( x).ToString());
                    listBox4.Items.Add(i.ToString());
                }
                if (Math.Abs(y - real_y) <distance)
                {
                    listBox2.Items.Add(i.ToString("X") + " y" + ( y).ToString());
                    listBox4.Items.Add(i.ToString());
                }
                if (Math.Abs( z - real_z) <distance)
                {
                    listBox2.Items.Add(i.ToString("X") + " z" + (z).ToString());
                    listBox4.Items.Add(i.ToString());
                }
            }
            label2.Text = "查找完毕共" + listBox2.Items.Count + "个符合条件";
            c1f = 1;
            button1.Enabled = true;
        }

        public void GetLocate2()
        {
            for (int i = 0x8000; i < 0x10000 ; i++)
            {
                //label2.Text = "正在查找" + i.ToString("X") + "个内存偏移";
                int tp = Helper.ReadMemoryValue32(baseadr, hProcess);
                float x = Helper.ReadMemoryFloat16(tp + i, hProcess);
                float y = Helper.ReadMemoryFloat16(tp + i, hProcess);
                float z = Helper.ReadMemoryFloat16(tp + i, hProcess);
                float real_x = Convert.ToSingle(textBox2.Text);
                float real_y = Convert.ToSingle(textBox3.Text);
                float real_z = Convert.ToSingle(textBox4.Text);
                if (Math.Abs( x - real_x) <distance)
                {
                    listBox2.Items.Add(i.ToString("X") + " x " + (x).ToString());
                    listBox4.Items.Add(i.ToString());
                }
                if (Math.Abs( y - real_y) <distance)
                {
                    listBox2.Items.Add(i.ToString("X") + " y" + ( y).ToString());
                    listBox4.Items.Add(i.ToString());
                }
                if (Math.Abs( z - real_z) <distance)
                {
                    listBox2.Items.Add(i.ToString("X") + " z" + ( z).ToString());
                    listBox4.Items.Add(i.ToString());
                }
              
            }
            label2.Text = "查找完毕共" + listBox2.Items.Count + "个符合条件";
            c2f = 1;
            button2.Enabled = true;
        }

        public void GetLocate3(int[] datas, int num)
        {
            for (int i = 0; i < num; i++)
            {
                //label2.Text = "正在查找" + i.ToString("X") + "个内存偏移";
                int tp = Helper.ReadMemoryValue32(baseadr, hProcess);
                float x = Helper.ReadMemoryFloat16(tp + datas[i], hProcess);
                float y = Helper.ReadMemoryFloat16(tp + datas[i], hProcess);
                float z = Helper.ReadMemoryFloat16(tp + datas[i], hProcess);

                float real_x = Convert.ToSingle(textBox2.Text);
                float real_y = Convert.ToSingle(textBox3.Text);
                float real_z = Convert.ToSingle(textBox4.Text);
                //if (x > -15600 && x < -15000 && y > 17000 && y < 18000)
                //{
                //    listBox2.Items.Add(datas[i].ToString("X"));
                //    listBox4.Items.Add(datas[i].ToString());
                //}
                if (Math.Abs(x - real_x) <distance)
                {
                    listBox2.Items.Add(datas[i].ToString("X") + " x");
                    listBox4.Items.Add(datas[i].ToString());
                }
                if (Math.Abs(y- real_y)<distance)
                {
                    listBox2.Items.Add(datas[i].ToString("X") + " y");
                    listBox4.Items.Add(datas[i].ToString());
                }
                if (Math.Abs(z- real_z) <distance)
                {
                    listBox2.Items.Add(datas[i].ToString("X") + " z");
                    listBox4.Items.Add(datas[i].ToString());
                }

            }
            label2.Text = "查找完毕共" + listBox2.Items.Count + "个符合条件";
            c2f = 1;
            button2.Enabled = true;
        }

        public void GetSpeed3(int[] datas, int num)
        {
            for (int i = 0; i < num; i++)
            {
                // label1.Text = "正在查找" + i.ToString("X") + "个内存偏移";
                int tp = Helper.ReadMemoryValue32(baseadr, hProcess);
                int data1 = Helper.ReadMemoryValue32(tp + datas[i], hProcess);
                int speed = Helper.ReadMemoryValue32(data1 + 8, hProcess);
                if ((speed ^ data1) - curspeeds > -dddddddx && (speed ^ data1) - curspeeds < dddddddx)
                {
                    listBox1.Items.Add(datas[i].ToString("X"));
                    listBox3.Items.Add(datas[i].ToString());
                }

            }
            label1.Text = "查找完毕共" + listBox1.Items.Count + "个符合条件";
            c1f = 1;
            button1.Enabled = true;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (baseadr == -1)
            {
                MessageBox.Show("请先输入基址");
                return;
            }
            button1.Enabled = false;
            if (listBox1.Items.Count == 0)
            {
                Thread t1 = new Thread(new ThreadStart(GetSpeed));
                Thread t2 = new Thread(new ThreadStart(GetSpeed2));
                t1.Start();
                t2.Start();
               
                c1f = 0;
            }
            else
            {

                int datanums = listBox1.Items.Count;
                int[] data = new int[datanums];
                for (int i = 0; i < datanums; i++)
                {
                    data[i] = Convert.ToInt32(listBox3.Items[i]);
                }
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                GetSpeed3(data, datanums);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         

            CheckForIllegalCrossThreadCalls = false;
            hProcess =Helper.GetPidByProcessName("dragonnest");
            listBox3.Visible = false;
            listBox4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baseadr == -1)
            {
                MessageBox.Show("请先输入基址");
                return;
            }
            button2.Enabled = false;
            if (listBox2.Items.Count == 0)
            {
                Thread t1 = new Thread(new ThreadStart(GetLocate));
                Thread t2 = new Thread(new ThreadStart(GetLocate2));
                t1.Start();
                t2.Start();
               
                c2f = 0;
            }
            else
            {
                int datanums = listBox2.Items.Count;
                int[] data = new int[datanums];
                for (int i = 0; i < datanums; i++)
                {
                    data[i] = Convert.ToInt32(listBox4.Items[i]);
                }
                listBox2.Items.Clear();
                listBox4.Items.Clear();
                GetLocate3(data, datanums);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            baseadr = Convert.ToInt32(textBox1.Text, 16);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getdelga asdasd = new getdelga(BaseFind.FindBaseAddr);

            IAsyncResult refd = asdasd.BeginInvoke(null,null);
            int result = asdasd.EndInvoke(refd);// <----收集 返回值
            textBox1.Text = result.ToString("X");
            MessageBox.Show("完");
        }



        void Endinvoke(IAsyncResult rst)
        {
            
        }
    }
}
