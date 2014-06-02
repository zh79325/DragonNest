using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlantsVsZombiesTool;
namespace hook1
{
    public partial class fly : Form
    {
        int xp = 0x826, yp = 0x82e, zp = 0x82A;
        int tmp;
       
      //  int zhanmove = 0, gongmove = 0, famove = 0, mumove = 0;
        string processname = "dragonnest";
        public fly()
        {
            InitializeComponent();
        }

        private void fly_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short tmp2=0, tmp1=0,tmp3=0;
            try
            {
                string num1 = "", num2 = "", num3 = "";
                num1 = textBox1.Text;
                num2 = textBox2.Text;
             

                if (num1.IndexOf("-") >= 0)
                {
                    tmp1 = Convert.ToInt16(num1.Substring(1));
                    tmp1 = (short)(-tmp1);
                }
                else
                    tmp1 = Convert.ToInt16(num1);
                if (num2.IndexOf("-") >= 0)
                {
                    tmp2 = Convert.ToInt16(num2.Substring(1));
                    tmp2 = (short)(-tmp2);
                }
                else
                    tmp2 = Convert.ToInt16(num2);
                //if (num3.IndexOf("-") >= 0)
                //{
                //    tmp3 = Convert.ToInt16(num3.Substring(1));
                //    tmp3 = (short)(-tmp3);
                //}
                //else
                //    tmp3 = Convert.ToInt16(num3);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
            if (tmp1 == 0 || tmp2 == 0)
            {
                MessageBox.Show("请输入正确的坐标");
                return;
            }
            if (tmp3 != 0)
            {
                ;// Helper.WriteMemoryValue16(tmp + zp, processname, tmp3);
            }
            Helper.WriteMemoryValue16(tmp + yp, processname, tmp2);
            Helper.WriteMemoryValue16(tmp + xp, processname, tmp1);
        }

        public void Set(int baseid,int xd,int yd,int zd,string  proname)
        {
            processname = proname;
            tmp = baseid;
            xp = xd;
            yp = yd;
            zp = zd;
        }
    }
}
