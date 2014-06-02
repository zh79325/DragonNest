using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HookGlobal;
using System.IO;
using System.Runtime.InteropServices;
using PlantsVsZombiesTool;
using System.Net;
using 无限闪避;

namespace hook1
{
    public partial class 无限闪避 : Form
    {
       
        KeyBordHook mykeyboardhook;
        int Base = 0x011be618;
        int Zhan = 0x1dd4 + 8, Gong = 0x1de4 + 8, Fa = 0xd4b8 + 8, Xue=0,Mu = 0x1eb8/* 0x1dcc + 8*/, Sec = 0x8, xp = 0xa5c, yp = 0xa64, zp = 0xa60;
        int normalspeed = 1000, highspeed = 2500, godspeed = 5000;
        int BaseSpeed = 0x00000000, FastSpeed = 0x0fffffff;
        int gamestarted = 0;
        int fastspeed;
        int orgspeed = 0;
        int tmp;
        int movdir = 15;
        float tmp1, tmp2;
        int needshutdown = 0;
        int zhanmove = 0, gongmove = 0, famove = 0, mumove = 0,xuemove=0;
        string processname ="dragonnest";
        float x = 100, y = -100;
        int geted = 0, moved = 0;
        int canmove = 0, movekind = 0;
        int nestkind = 3;
        Point curp, lastp;
        bool Getcurp = false;
        ToolStripMenuItem []nestmenu;
        KeyChange form2;
        fly FlyForm;
        Nest[] movenest;
        public   int cf = 0;
        int movenestnum=0;
        public   string RemLocateKey = "F1", MoveKey = "Q", SpeedUpKey = "F5";
        string version = "";
        float prevx, prevy, prevz;
        float currentx, currenty, currentz;





        public 无限闪避()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;

            CheckUpdate();
           
            Init();
         

            gamestarted = 1;
          
            groupBox1.Visible = true;
            checkbox1.Enabled = true;
            tmp=Helper.ReadMemoryValue32(Base, processname);
            zhanmove = Helper.ReadMemoryValue32((tmp + Zhan), processname);
            gongmove = Helper.ReadMemoryValue32((tmp + Gong ), processname);
            famove = Helper.ReadMemoryValue32((tmp + Fa), processname);
            mumove = Helper.ReadMemoryValue32((tmp + Mu), processname);
            toolStripMenuItem6.Checked = true;
            中速ToolStripMenuItem.Checked = true;
            高速ToolStripMenuItem.Checked = false;
            fastspeed = normalspeed;

        }
       

        void NestMenu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < movenestnum; i++)
            {
                if (sender.ToString() == movenest[i].nestname)
                {
                    nestmenu[i].Checked = true;
                    label1.Text = sender.ToString();
                    comboBox1.SelectedIndex = -1;                  
                    nestkind = i;
                    comboBox1.Items.Clear();
                    for (int j = 0; j < movenest[i].movepointnum; j++)
                    {
                        comboBox1.Items.Add( movenest[i].movepointname[j]);
                    }
                }
                else
                {
                    nestmenu[i].Checked = false;
                }
            }
        }

        void mykeyboardhook_OnKeyDownEvent(object sender, KeyEventArgs e)
        {
           if (gamestarted == 1)
            {
                tmp = Helper.ReadMemoryValue32(Base, processname);
                zhanmove = Helper.ReadMemoryValue32((tmp + Zhan), processname);
                gongmove = Helper.ReadMemoryValue32((tmp + Gong), processname);
                famove = Helper.ReadMemoryValue32((tmp + Fa), processname);
                mumove = Helper.ReadMemoryValue32((tmp + Mu), processname);
                xuemove = Helper.ReadMemoryValue32((tmp + Xue), processname);
                if (orgspeed > 0)
                {
                    if (Abs(normalspeed - orgspeed) < 200 || Abs(highspeed - orgspeed) < 200 || Abs(godspeed - orgspeed) < 200)
                    {
                        switch (movekind)
                        {
                            case 2:
                                BaseSpeed = Helper.ReadMemoryValue32((mumove + Sec), processname);
                                orgspeed = BaseSpeed ^ mumove;
                                break;
                            case 1:
                                BaseSpeed = Helper.ReadMemoryValue32((zhanmove + Sec), processname);
                                orgspeed = BaseSpeed ^ zhanmove;
                                break;
                            case 3:
                                BaseSpeed = Helper.ReadMemoryValue32((famove + Sec), processname);
                                orgspeed = BaseSpeed ^ famove;
                                break;
                            case 4:
                                BaseSpeed = Helper.ReadMemoryValue32((gongmove + Sec), processname);
                                orgspeed = BaseSpeed ^ gongmove;
                                break;
                            case 5:
                                BaseSpeed = Helper.ReadMemoryValue32((xuemove + Sec), processname);
                                orgspeed = BaseSpeed ^ xuemove;
                                break;
                        }

                    }
                }
                Console.WriteLine(e.KeyData.ToString());
                if (e.KeyData.ToString() == RemLocateKey)
                {
                    MyMove1();
                }

                else if (e.KeyData.ToString() == MoveKey)
                {
                    MyMove();
                }
                else if (e.KeyData.ToString() == SpeedUpKey)
                {
                    if (canmove == 1)
                    {
                        Speedup2();
                    }
                }
                else if (e.KeyData.ToString() == "Up")
                {
                    if(Getcurp==true)
                        MoveDirect(1, movdir);
                }
                else if (e.KeyData.ToString() == "Down")
                {
                    if (Getcurp == true)
                        MoveDirect(4,movdir);
                }

               switch(e.KeyData.ToString())
               {
                   case "NumPad0":
                       ClickRow(0);
                       break;
                   case "NumPad1":
                       ClickRow(1);
                       break;
                   case "NumPad2":
                       ClickRow(2);
                       break;
                   case "NumPad3":
                       ClickRow(3);
                       break;
                   case "NumPad4":
                       ClickRow(4);
                       break;
                   case "NumPad5":
                       ClickRow(5);
                       break;
                   case "NumPad6":
                       ClickRow(6);
                       break;
                   case "NumPad7":
                       ClickRow(7);
                       break;
                   case "NumPad8":
                       ClickRow(8);
                       break;
                   case "NumPad9":
                       ClickRow(9);
                       break;
                   default :
                       break;
               }

            }
            
           //  throw new NotImplementedException();
        }

        void ClickRow(int row)
        {
            if (!checkBox3.Checked)
                return;
            tmp = Helper.ReadMemoryValue32(Base, processname);
            float x = (float)dataGridView1.Rows[row].Cells[1].Value;
            float y = (float)dataGridView1.Rows[row].Cells[2].Value;
            float z = (float)dataGridView1.Rows[row].Cells[3].Value;

            Helper.WriteMemoryValue32(tmp + zp, processname, z);
            Helper.WriteMemoryValue32(tmp + yp, processname, y);
            Helper.WriteMemoryValue32(tmp + xp, processname, x);
        }
        void MyMove1()
        {
            geted = 1;
            moved = 0;
            prevx = Helper.ReadMemoryFloat16(tmp + xp, processname);
            prevy = Helper.ReadMemoryFloat16(tmp + yp, processname);
            prevz = Helper.ReadMemoryFloat16(tmp + yp, processname);
            //DataGridViewRow r = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            //r.Cells[1].Value = prevx;
            //r.Cells[2].Value = prevy;
            //r.Cells[3].Value = prevz;
            //dataGridView1.Rows.Add(r);
            //float x = (float)dataGridView1.Rows[row].Cells[1].Value;
            //float y = (float)dataGridView1.Rows[row].Cells[2].Value;
            //float z = (float)dataGridView1.Rows[row].Cells[3].Value;
        }

        void MyMove()
        {
            if ( moved == 0)
            {
                x = Helper.ReadMemoryFloat16(tmp + xp, processname);
                y = Helper.ReadMemoryFloat16(tmp + yp, processname);

                currentx = Helper.ReadMemoryFloat16(tmp + xp, processname);
                currenty = Helper.ReadMemoryFloat16(tmp + yp, processname);
                currentz = Helper.ReadMemoryFloat16(tmp + zp, processname);
           
                Helper.WriteMemoryValue32(tmp + zp, processname, prevz);
                Helper.WriteMemoryValue32(tmp + yp, processname, prevy);
                Helper.WriteMemoryValue32(tmp + xp, processname, prevx);
                moved = 1;
               
            }
            else if ( moved == 1)
            {
                moved = 0;
                Helper.WriteMemoryValue32(tmp + yp, processname, currenty);
                Helper.WriteMemoryValue32(tmp + zp, processname, currentz);
                Helper.WriteMemoryValue32(tmp + xp, processname, currentx);
            }
        }

        void Speedup()
        {
          
            switch (movekind)
            {
                case 1:
                    BaseSpeed = Helper.ReadMemoryValue32((zhanmove + Sec), processname);
                    FastSpeed = BaseSpeed ^ fastspeed;
                   Helper.WriteMemoryValue32((zhanmove + Sec), processname, FastSpeed);
                  //  Helper.WriteMemoryValue32((tmp + Zhan), processname, FastSpeed);
                    break;
                case 2:
                    BaseSpeed = Helper.ReadMemoryValue32((mumove + Sec), processname);
                    FastSpeed = BaseSpeed ^ fastspeed;
                    Helper.WriteMemoryValue32((mumove + Sec), processname, FastSpeed);
                   // Helper.WriteMemoryValue32((tmp + Mu), processname, FastSpeed);
                    break;
                case 3:
                    BaseSpeed = Helper.ReadMemoryValue32((famove + Sec), processname);
                    FastSpeed = BaseSpeed ^ fastspeed;
                  Helper.WriteMemoryValue32((famove + Sec), processname, FastSpeed);
                  //  Helper.WriteMemoryValue32((tmp + Fa), processname, FastSpeed);
                    break;
                case 4:
                    BaseSpeed =Helper.ReadMemoryValue32((gongmove + Sec), processname);
                    FastSpeed = BaseSpeed ^ fastspeed;
                    Helper.WriteMemoryValue32((gongmove + Sec), processname, FastSpeed);
                  //  Helper.WriteMemoryValue32((tmp + Gong), processname, FastSpeed);
                    break;
                case 5:
                     BaseSpeed =Helper.ReadMemoryValue32((xuemove + Sec), processname);
                    FastSpeed = BaseSpeed ^ fastspeed;
                    Helper.WriteMemoryValue32((xuemove + Sec), processname, FastSpeed);
                    break;
            }
        }
        int Abs(int a)
        {
            return  a>0?a:0-a;
        }

        void Speedup2()
        {
            int speeds = 0;

            switch (movekind)
            {
                case 1:
                    BaseSpeed = Helper.ReadMemoryValue32((zhanmove + Sec), processname);
                    
                   
                     speeds = BaseSpeed ^ zhanmove;
                     if (Abs(normalspeed - speeds) < 200 || Abs(highspeed - speeds) < 200 || Abs(godspeed - speeds) < 200)
                        speeds = orgspeed;
                    else
                        speeds = fastspeed;
                    FastSpeed = speeds ^ zhanmove;


                    Helper.WriteMemoryValue32((zhanmove + Sec), processname, FastSpeed);
                    //  Helper.WriteMemoryValue32((tmp + Zhan), processname, FastSpeed);
                    break;
                case 2:
                    BaseSpeed = Helper.ReadMemoryValue32((mumove + Sec), processname);
                    speeds = BaseSpeed ^ mumove;
                    if (Abs(normalspeed - speeds) < 200 || Abs(highspeed - speeds) < 200 || Abs(godspeed - speeds) < 200)
                        speeds = orgspeed;
                    else
                        speeds = fastspeed;
                    FastSpeed = speeds ^ mumove;
                    Helper.WriteMemoryValue32((mumove + Sec), processname, FastSpeed);
                    // Helper.WriteMemoryValue32((tmp + Mu), processname, FastSpeed);
                    break;
                case 3:
                    BaseSpeed = Helper.ReadMemoryValue32((famove + Sec), processname);
                    speeds = BaseSpeed ^ famove;
                    if (Abs(normalspeed - speeds) < 200 || Abs(highspeed - speeds) < 200 || Abs(godspeed - speeds) < 200)
                        speeds = orgspeed;
                    else
                        speeds = fastspeed;
                    FastSpeed = speeds ^ famove;

                    Helper.WriteMemoryValue32((famove + Sec), processname, FastSpeed);
                    //  Helper.WriteMemoryValue32((tmp + Fa), processname, FastSpeed);
                    break;
                case 4:
                    BaseSpeed = Helper.ReadMemoryValue32((gongmove + Sec), processname);
                     speeds = BaseSpeed ^ gongmove;
                     if (Abs(normalspeed - speeds) < 200 || Abs(highspeed - speeds) < 200 || Abs(godspeed - speeds) < 200)
                         speeds = orgspeed;
                     else
                         speeds = fastspeed;
                    FastSpeed = speeds ^ gongmove;
                    Helper.WriteMemoryValue32((gongmove + Sec), processname, FastSpeed);
                    //  Helper.WriteMemoryValue32((tmp + Gong), processname, FastSpeed);
                    break;
                case 5:
                    BaseSpeed = Helper.ReadMemoryValue32((xuemove + Sec), processname);
                    speeds = BaseSpeed ^ xuemove;
                    if (Abs(normalspeed - speeds) < 200 || Abs(highspeed - speeds) < 200 || Abs(godspeed - speeds) < 200)
                        speeds = orgspeed;
                    else
                        speeds = fastspeed;
                    FastSpeed = speeds ^ xuemove;
                    Helper.WriteMemoryValue32((xuemove + Sec), processname, FastSpeed);
                    //  Helper.WriteMemoryValue32((tmp + Gong), processname, FastSpeed);
                    break;
            }
        }

        void SpecilaMove(float movetox, float movetoy)
        {
            Helper.WriteMemoryValue32(tmp + yp, processname, movetoy);
            Helper.WriteMemoryValue32(tmp + xp, processname, movetox);
        }

        void MoveDirect(int i,int step)
        {
            Point nextp=new Point(0,0);
            if (lastp.X == 0 && lastp.Y == 0)
                return;
            if (curp.X < lastp.X)
                step *= -1;
            
                switch (i)
                {
                    case 1:
                        if (lastp.X == curp.X)
                        {
                            nextp.X = lastp.X;
                            nextp.Y = curp.Y + step;
                        }
                        else if (lastp.Y == curp.Y)
                        {
                            nextp.Y = lastp.Y;
                            nextp.X = curp.X + step;
                        }
                        else
                        {
                            nextp.Y = curp.Y + (int)(step * Math.Sin(Math.Atan((double)(curp.Y - lastp.Y) / (curp.X - lastp.X))));
                            nextp.X = curp.X + (int)(step * Math.Cos(Math.Atan((double)(curp.Y - lastp.Y) / (curp.X - lastp.X))));
                        }                 
                        break;
                    case 4:
                        if (lastp.X == curp.X)
                        {
                            nextp.X = lastp.X;
                            nextp.Y = curp.Y - step;
                        }
                        else if (lastp.Y == curp.Y)
                        {
                            nextp.Y = lastp.Y;
                            nextp.X = curp.X - step;
                        }
                        else
                        {
                            nextp.Y = curp.Y - (int)(step * Math.Sin(Math.Atan((double)(curp.Y - lastp.Y) / (curp.X - lastp.X))));
                            nextp.X = curp.X - (int)(step * Math.Cos(Math.Atan((double)(curp.Y - lastp.Y) / (curp.X - lastp.X))));
                        }                                         
                        break;
                    case 3:
                        if (lastp.X == curp.X)
                        {
                            nextp.Y = lastp.Y;
                            nextp.X = curp.X + step;
                        }
                        else if (lastp.Y == curp.Y)
                        {
                            nextp.X = lastp.X;
                            nextp.Y = curp.Y + step;
                        }
                        else
                        {
                            nextp.Y = curp.Y - (int)(step * Math.Sin(Math.Atan((double)(curp.Y - lastp.Y) / (curp.X - lastp.X))));
                            nextp.X = curp.X + step;
                        }                 
                        break;
                    case 2:
                        break;
                }
            
          
            tmp = Helper.ReadMemoryValue32(Base, processname);
            Helper.WriteMemoryValue16(tmp + xp, processname,(short)nextp.X);
            Helper.WriteMemoryValue16(tmp + yp, processname, (short)nextp.Y);
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tmp = Helper.ReadMemoryValue32(Base, processname);
                zhanmove = Helper.ReadMemoryValue32((tmp + Zhan), processname);
               
                BaseSpeed = Helper.ReadMemoryValue32((zhanmove+Sec),processname);
                orgspeed = BaseSpeed ^ zhanmove;
                FastSpeed = BaseSpeed ^ fastspeed;
                movekind = 1;
            }
        }

        private void checkbox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (Helper.FindWindow(processname) == IntPtr.Zero)
            //{
            //    MessageBox.Show("请先启动游戏");
            //    return;
            //}
            if (checkbox1.Checked == true)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                canmove = 1;
            }
            else
            {
                canmove = 0;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                tmp = Helper.ReadMemoryValue32(Base, processname);
                
                mumove = Helper.ReadMemoryValue32((tmp + Mu), processname);
                BaseSpeed = Helper.ReadMemoryValue32((mumove + Sec), processname);
                orgspeed = BaseSpeed ^ mumove;              
                FastSpeed = BaseSpeed ^ fastspeed;
                movekind = 2;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                tmp = Helper.ReadMemoryValue32(Base, processname);
              
                gongmove = Helper.ReadMemoryValue32((tmp + Gong), processname);
              
                BaseSpeed = Helper.ReadMemoryValue32((gongmove + Sec), processname);
                orgspeed = BaseSpeed ^gongmove;
                FastSpeed = BaseSpeed ^ fastspeed;
                movekind = 4;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                tmp = Helper.ReadMemoryValue32(Base, processname);
               
                famove = Helper.ReadMemoryValue32((tmp + Fa), processname);
             
                BaseSpeed = Helper.ReadMemoryValue32((famove + Sec), processname);
                orgspeed = BaseSpeed ^ famove;
                FastSpeed = BaseSpeed ^ fastspeed;
                movekind = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            gamestarted = 1;
            if (Helper.GetPidByProcessName(processname) == 0)
            {
                gamestarted = 0;
                MessageBox.Show("请先启动游戏，再启动外挂");
                checkbox1.Enabled = false;
              
                groupBox1.Visible = false;
              
                return;
            }
          
            groupBox1.Visible = true;
            checkbox1.Enabled = true;
            tmp = Helper.ReadMemoryValue32(Base, processname);
            zhanmove = Helper.ReadMemoryValue32((tmp + Zhan), processname);
            gongmove = Helper.ReadMemoryValue32((tmp + Gong), processname);
            famove = Helper.ReadMemoryValue32((tmp + Fa), processname);
            mumove = Helper.ReadMemoryValue32((tmp + Mu), processname);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //short movx = 0, movy = 0;
            //if (Helper.FindWindow(processname) == IntPtr.Zero)
            //{
            //    MessageBox.Show("请先启动游戏");
            //    return;
            //}
            tmp = Helper.ReadMemoryValue32(Base, processname);
            zhanmove = Helper.ReadMemoryValue32((tmp + Zhan), processname);
            gongmove = Helper.ReadMemoryValue32((tmp + Gong), processname);
            famove = Helper.ReadMemoryValue32((tmp + Fa), processname);
            mumove = Helper.ReadMemoryValue32((tmp + Mu), processname);
            SpecilaMove(movenest[nestkind].movex[comboBox1.SelectedIndex], movenest[nestkind].movey[comboBox1.SelectedIndex]);           
        }

        private void 使用帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string shomsg = "先按" + RemLocateKey + "记录位置" + " " + "按" + MoveKey + "瞬移到记录的位置" + "\n\n" + "选择好职业后按" + SpeedUpKey + "加速再按" + SpeedUpKey + "恢复速度\n";
            shomsg += "开启前后瞬移后按方向键可以穿墙\n";
            MessageBox.Show(shomsg);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            float tempx=0, tempy=0,tempz=0;
            tmp = Helper.ReadMemoryValue32(Base, processname);
            zhanmove = Helper.ReadMemoryValue32((tmp + Zhan), processname);
            gongmove = Helper.ReadMemoryValue32((tmp + Gong), processname);
            famove = Helper.ReadMemoryValue32((tmp + Fa), processname);
            mumove = Helper.ReadMemoryValue32((tmp + Mu), processname);
            xuemove = Helper.ReadMemoryValue32((tmp + Xue), processname);
            tempx = Helper.ReadMemoryFloat16(tmp + xp, processname);
            tempy = Helper.ReadMemoryFloat16(tmp + yp, processname);
            tempz = Helper.ReadMemoryFloat16(tmp + zp, processname);
            int BaseSpeed1=0, orgspeed1=0;
            switch (movekind)
            {
                case 2:
                    BaseSpeed1 = Helper.ReadMemoryValue32((mumove + Sec), processname);
                    orgspeed1 = BaseSpeed1 ^ mumove;
                    break;
                case 1:
                    BaseSpeed1 = Helper.ReadMemoryValue32((zhanmove + Sec), processname);
                    orgspeed1 = BaseSpeed1 ^ zhanmove;
                    break;
                case 3:
                    BaseSpeed1 = Helper.ReadMemoryValue32((famove + Sec), processname);
                    orgspeed1 = BaseSpeed1 ^ famove;
                    break;
                case 4:
                    BaseSpeed1 = Helper.ReadMemoryValue32((gongmove + Sec), processname);
                    orgspeed1 = BaseSpeed1 ^ gongmove;
                    break;
                case 5:
                      BaseSpeed1 = Helper.ReadMemoryValue32((xuemove + Sec), processname);
                      orgspeed1 = BaseSpeed1 ^ xuemove;
                    break;
                    
            }
            MessageBox.Show("X:" + tempx.ToString() + " Y:" + tempy.ToString()+"\n当前速度："+orgspeed1.ToString(),"人物信息");

        }

        private void 天启巢穴帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("自求多福");

        }

        private void 键位修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new KeyChange();
            form2.Show();
            form2.Owner = this;
            form2.KeyDown += new KeyEventHandler(form2_KeyDown);
            
        }

        void form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (form2.KeyChangeReady == 1)
            {
                switch (form2.ChangeKeyKind)
                {
                    case 1:
                       //form2.label5.Text = e.KeyData.ToString();
                        form2.KeyChangeReady = 0;
                       // form2.label5.BorderStyle = BorderStyle.FixedSingle;
                        form2.SetLael(5, e.KeyData.ToString());
                        RemLocateKey = e.KeyData.ToString();
                        break;
                    case 2:
                        form2.SetLael(6, e.KeyData.ToString());
                      //  form2.label6.Text = e.KeyData.ToString();
                        form2.KeyChangeReady = 0;
                        MoveKey = e.KeyData.ToString();
                       // form2.label6.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case 3:
                        form2.SetLael(7, e.KeyData.ToString());
                      //  form2.label7.Text = e.KeyData.ToString();
                        form2.KeyChangeReady = 0;
                        SpeedUpKey = e.KeyData.ToString();
                      //  form2.label7.BorderStyle = BorderStyle.FixedSingle;
                        break;
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            tmp = Helper.ReadMemoryValue32(Base, processname);
            FlyForm = new fly();
            FlyForm.Show();
            FlyForm.Set(tmp, xp, yp,zp, processname);
        }

        private void 中速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            中速ToolStripMenuItem.Checked = true;
            高速ToolStripMenuItem.Checked = false;
            神速ToolStripMenuItem.Checked = false;
            fastspeed = normalspeed;

        }

        private void 高速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            中速ToolStripMenuItem.Checked = false;
            高速ToolStripMenuItem.Checked = true;
            神速ToolStripMenuItem.Checked = false;
            fastspeed = highspeed;
        }

        private void 神速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            中速ToolStripMenuItem.Checked = false;
            高速ToolStripMenuItem.Checked = false;
            神速ToolStripMenuItem.Checked = true;
            fastspeed = godspeed;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                timer1.Enabled = true;
                int tempx = 0, tempy = 0;
                tmp = Helper.ReadMemoryValue32(Base, processname);           
                tempx = Helper.ReadMemoryValue16(tmp + xp, processname);
                tempy = Helper.ReadMemoryValue16(tmp + yp, processname);
                curp.X = tempx;
                curp.Y = tempy;
                Getcurp = true;
            }
            else
            {
                timer1.Enabled = false;
                Getcurp = false;
                lastp.X = 0;
                lastp.Y = 0;
                needshutdown = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tempx = 0, tempy = 0;
            tmp = Helper.ReadMemoryValue32(Base, processname);
            tempx = Helper.ReadMemoryValue16(tmp + xp, processname);
            tempy = Helper.ReadMemoryValue16(tmp + yp, processname);
            if (tempy == 0 && tempx == 0)
            {
                needshutdown++;
                if (needshutdown > 100)
                {
                    timer1.Enabled = false;
                    Getcurp = false;
                    lastp.X = 0;
                    lastp.Y = 0;
                    needshutdown = 0;
                    checkBox2.Checked = false;
                }
            }
            else
            {
                needshutdown = 0;
                if (curp.X != tempx && curp.Y != tempy)
                {

                    lastp.X = curp.X;
                    lastp.Y = curp.Y;
                    curp.X = tempx;
                    curp.Y = tempy;
                }
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 新增飞行点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            自定义飞行点 f = new 自定义飞行点();
            f.Show();
            f.init(Base, xp, yp,processname,this);
        }

        private void 键位修改ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            form2 = new KeyChange();
            form2.Show();
            form2.Owner = this;
            form2.KeyDown += new KeyEventHandler(form2_KeyDown);
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            tmp = Helper.ReadMemoryValue32(Base, processname);
            FlyForm = new fly();
            FlyForm.Show();
            FlyForm.Set(tmp, xp, yp, zp, processname);
        }

        private void 新增飞行点ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            自定义飞行点 f = new 自定义飞行点();
            cf = 0;
            f.init(Base, xp, yp, processname,this);
            f.Show();
         
            timer2.Enabled = true;
           
        }

        void Init()
        {

            mykeyboardhook = new KeyBordHook();
            mykeyboardhook.Start();
            mykeyboardhook.OnKeyDownEvent += new KeyEventHandler(mykeyboardhook_OnKeyDownEvent);
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            StreamReader infile = new StreamReader("Set.ini", Encoding.GetEncoding("gb2312"));
            string tempstring = infile.ReadLine();
            tempstring = tempstring.Substring(tempstring.IndexOf("\"") + 1);
            RemLocateKey = tempstring.Substring(0, tempstring.IndexOf("\""));
            tempstring = infile.ReadLine();
            tempstring = tempstring.Substring(tempstring.IndexOf("\"") + 1);
            MoveKey = tempstring.Substring(0, tempstring.IndexOf("\""));
            tempstring = infile.ReadLine();
            tempstring = tempstring.Substring(tempstring.IndexOf("\"") + 1);
            SpeedUpKey = tempstring.Substring(0, tempstring.IndexOf("\""));
            tempstring = infile.ReadLine();
            int nestnum = Convert.ToInt32(tempstring.Substring(tempstring.IndexOf("=") + 1));
            movenestnum = nestnum;
            if (movenest != null)
                movenest = null;
            movenest = new Nest[nestnum];
            if (nestmenu != null)
                nestmenu = null;
            nestmenu = new ToolStripMenuItem[nestnum];
            副本选择ToolStripMenuItem.DropDownItems.Clear();
            for (int j = 0; j < nestnum; j++)
            {

                tempstring = infile.ReadLine();
                string nestname = tempstring.Substring(tempstring.IndexOf("=") + 1);
                tempstring = infile.ReadLine();
                int nestmovenum = Convert.ToInt32(tempstring.Substring(tempstring.IndexOf("=") + 1));
                movenest[j] = new Nest(nestname, nestmovenum);
                nestmenu[j] = new ToolStripMenuItem(nestname);
                副本选择ToolStripMenuItem.DropDownItems.Add(nestmenu[j]);
                nestmenu[j].Click += new EventHandler(NestMenu_Click);
                movenest[j].ReadNest("Locate.txt");

            }
            infile.Close();


            nestmenu[0].Checked = true;
            label1.Text = movenest[0].nestname;
            comboBox1.SelectedIndex = -1;
            nestkind = 0;
            comboBox1.Items.Clear();
            for (int j = 0; j < movenest[0].movepointnum; j++)
            {
                comboBox1.Items.Add(movenest[0].movepointname[j]);
            }
        }

        void CheckUpdate()
        {
           
            if(true)
            {
                return;
            }
           
           
            HttpWebRequest hrq = (HttpWebRequest)WebRequest.Create("http://hi.baidu.com/zhou7758437/blog/item/47504e1f2528c070f624e428.html?timeStamp=1313134483923");
            HttpWebResponse hrp = (HttpWebResponse)hrq.GetResponse();
            string sss = hrp.CharacterSet;
            StreamReader sr = new StreamReader(hrp.GetResponseStream(),Encoding.GetEncoding("GB2312"));
            string text = sr.ReadToEnd();
            sr.Close();
            hrp.Close();

           
            int s = text.IndexOf("版本：") + "版本：".Length;
            int l= text.IndexOf("版本结束")-s;
             string  temopversion=text.Substring(s, l);
             temopversion.Trim();
             temopversion.ToUpper();
             
                 s = text.IndexOf("基址：") + "基址：".Length;
                 l = text.IndexOf("基址结束") - s;
                 Base = Convert.ToInt32(text.Substring(s, l), 16);

                 s = text.IndexOf("牧师偏移：") + "牧师偏移：".Length;
                 l = text.IndexOf("牧师偏移结束") - s;
                 Mu = Convert.ToInt32(text.Substring(s, l), 16);

                 s = text.IndexOf("二级偏移：") + "二级偏移：".Length;
                 l = text.IndexOf("二级偏移结束") - s;
                 Sec = Convert.ToInt32(text.Substring(s, l), 16);

                 s = text.IndexOf("X偏移：") + "X偏移：".Length;
                 l = text.IndexOf("X偏移结束") - s;
                 xp = Convert.ToInt32(text.Substring(s, l), 16);

                 Zhan = 0x1dd4 - 0x1dcc + Mu;
                 Gong = 0x1de4 - 0x1dcc + Mu;
                Fa = 0x1dfc - 0x1dcc + Mu;
                 yp = 0x83e - 0x836 + xp;
                 Xue = 0x1ed0 - 0x1eb8 + Mu;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cf == 1)
            {
                cf = 0;
                Init();
                timer2.Enabled = false;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            movdir = 15;
            toolStripMenuItem6.Checked = true;
            toolStripMenuItem7.Checked =false;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            movdir = 20;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked =true;
            toolStripMenuItem8.Checked = false;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            movdir = 50;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = true;
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckUpdate();
            MessageBox.Show("更新完成","完成");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                tmp = Helper.ReadMemoryValue32(Base, processname);
                
                xuemove = Helper.ReadMemoryValue32((tmp + Xue), processname);
                BaseSpeed = Helper.ReadMemoryValue32((xuemove + Sec), processname);
                orgspeed = BaseSpeed ^ xuemove;
                FastSpeed = BaseSpeed ^ fastspeed;

                movekind = 5;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            float x = (float)dataGridView1.Rows[row].Cells[1].Value;
            float y = (float)dataGridView1.Rows[row].Cells[2].Value;
            float z = (float)dataGridView1.Rows[row].Cells[3].Value;
            tmp = Helper.ReadMemoryValue32(Base, processname);
            Helper.WriteMemoryValue32(tmp + zp, processname, z);
            Helper.WriteMemoryValue32(tmp + yp, processname, y);
            Helper.WriteMemoryValue32(tmp + xp, processname, x);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // KeyMessage.SendKey(processname, Keys.1);
            
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(filename,Encoding.GetEncoding("gb2312"));
            dataGridView1.Rows.Clear();
            while(!sr.EndOfStream)
            {
                string line=sr.ReadLine();
                string []lparams=line.Split('#');
                DataGridViewRow r = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                r.Cells[0].Value = lparams[0];
                r.Cells[1].Value = lparams[1]==""?0:Convert.ToSingle(lparams[1]);
                r.Cells[2].Value =lparams[2]==""?0: Convert.ToSingle(lparams[2]);
                if (lparams.Length==4)
                {
                    r.Cells[3].Value =lparams[3]==""?0: Convert.ToSingle(lparams[3]);
                }
                else
                {
                    r.Cells[3].Value = 0;
                }
                
                dataGridView1.Rows.Add(r);

            }
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           float tprevx = Helper.ReadMemoryFloat16(tmp + xp, processname);
           float tprevy = Helper.ReadMemoryFloat16(tmp + yp, processname);
           float tprevz = Helper.ReadMemoryFloat16(tmp + zp, processname);
            DataGridViewRow r = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            r.Cells[0].Value = string.Format("坐标{0}", dataGridView1.Rows.Count+1);
            r.Cells[1].Value = tprevx;
            r.Cells[2].Value = tprevy;
            r.Cells[3].Value = tprevz;
            dataGridView1.Rows.Add(r);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string savename = saveFileDialog1.FileName;
            FileStream fs = new FileStream(savename, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            for (int i = 0; i < dataGridView1.Rows.Count;i++ )
            {
                string line = string.Format("{0}#{1}#{2}#{3}",
                    dataGridView1.Rows[i].Cells[0].Value,
                    dataGridView1.Rows[i].Cells[1].Value,
                    dataGridView1.Rows[i].Cells[2].Value,
                    dataGridView1.Rows[i].Cells[3].Value);
                sw.WriteLine(line);
            }
                sw.Close();
            fs.Close();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            float tempx = 0, tempy = 0, tempz = 0;
            int tmpbase = Helper.ReadMemoryValue32(Base, processname);

            tempx = Helper.ReadMemoryFloat16(tmpbase + xp, processname);
            tempy = Helper.ReadMemoryFloat16(tmpbase + yp, processname);
            tempz = Helper.ReadMemoryFloat16(tmpbase + zp, processname);
            label2.Text = string.Format("x:{0} y:{1} z:{2}", tempx, tempy, tempz);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KeyMessage.SendKey(processname, Keys.D1);
        }
      
    }

   
}
