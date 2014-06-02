using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlantsVsZombiesTool;


namespace 内存查看工具
{
    public partial class MemoryView : Form
    {
        int hProcess;
        string processname = "";
        int ishex = 0;
        int basadr = 0;
        int kind = -1;
        public MemoryView()
        {
            InitializeComponent();
        }

        private void MemoryView_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            processname= textBox2.Text;
            hProcess = Helper.GetPidByProcessName(processname);
            if (hProcess == 0)
            {
                MessageBox.Show("不存在该进程");
            }
        }

        private void HEX_CheckedChanged(object sender, EventArgs e)
        {
            if (HEX.Checked == true)
                ishex = 1;
            else ishex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processname = "XCB.dat";
            try
            {
                if (ishex == 1)
                {
                    basadr = Convert.ToInt32(textBox1.Text, 16);
                }
                else
                    basadr = Convert.ToInt32(textBox1.Text, 16);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                return;
            }
            if (kind == -1)
            {
                MessageBox.Show("请先选择数据类型");
                return;
            }
            int a = 0;
            short b = 0;
            string process = processname.Substring(0, processname.IndexOf('.'));
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dataGridView1);
            dr.Cells[0].Value = dataGridView1.Rows.Count;
            dr.Cells[1].Value = "";
            dr.Cells[2].Value = basadr.ToString("X");
            dr.Cells[3].Value = comboBox1.SelectedText;
           
            switch (kind)
            {
                case 0:
                    a = Helper.ReadMemoryValue32(basadr, processname);
                    dr.Cells[4].Value = a;
                    break;
                case 1:
                    b = Helper.ReadMemoryValue16(basadr, processname);
                    dr.Cells[4].Value = b;
                    break;
            }
           
            dataGridView1.Rows.Add(dr);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kind = comboBox1.SelectedIndex;
        }
    }
}
