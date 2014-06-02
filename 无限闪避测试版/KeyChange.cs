using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HookGlobal;
using System.IO;
namespace hook1
{
    public partial class KeyChange : Form 
    {
       
      public   int KeyChangeReady = 0;
      public  int ChangeKeyKind = 0;
        public KeyChange()
        {
            InitializeComponent();
        }

        private void KeyChange_Load(object sender, EventArgs e)
        {
          
          
            label1.Text = "选中要修改的按键";
           
            label5.Click += new EventHandler(label5_Click);
            label6.Click += new EventHandler(label6_Click);
            label7.Click += new EventHandler(label7_Click);
            label5.AutoSize = false;
            label6.AutoSize = false;
            label7.AutoSize = false;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label6.BorderStyle = BorderStyle.FixedSingle;
            //this.KeyDown+=new KeyEventHandler(KeyChange_KeyDown);
            StreamReader infile = new StreamReader("Set.ini");
            string tempstring = infile.ReadLine();
            tempstring = tempstring.Substring(tempstring.IndexOf("\"") + 1);
            label5.Text= tempstring.Substring(0, tempstring.IndexOf("\""));
            tempstring = infile.ReadLine();
            tempstring = tempstring.Substring(tempstring.IndexOf("\"") + 1);
            label6.Text = tempstring.Substring(0, tempstring.IndexOf("\""));
            tempstring = infile.ReadLine();
            tempstring = tempstring.Substring(tempstring.IndexOf("\"") + 1);
            label7.Text = tempstring.Substring(0, tempstring.IndexOf("\""));
            infile.Close();

        }

        void label7_Click(object sender, EventArgs e)
        {
            ChangeKeyKind = 3;
            KeyChangeReady = 1;
            label1.Text = "请按键";
            label7.BorderStyle = BorderStyle.Fixed3D;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label6.BorderStyle = BorderStyle.FixedSingle;
        }

        void label6_Click(object sender, EventArgs e)
        {
            ChangeKeyKind = 2;
            KeyChangeReady = 1;
            label1.Text = "请按键";
            label6.BorderStyle = BorderStyle.Fixed3D;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label7.BorderStyle = BorderStyle.FixedSingle;
        }

        //void KeyChange_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (KeyChangeReady == 1)
        //    {
        //        switch (ChangeKeyKind)
        //        {
        //            case 1:
        //                label5.Text = e.KeyData.ToString();
        //                KeyChangeReady = 0;
        //                label5.BorderStyle = BorderStyle.FixedSingle;
        //                break;
        //            case 2:
        //                label6.Text = e.KeyData.ToString();
        //                KeyChangeReady = 0;
        //                label6.BorderStyle = BorderStyle.FixedSingle;
        //                break;
        //            case 3:
        //                label7.Text = e.KeyData.ToString();
        //                KeyChangeReady = 0;
        //                label7.BorderStyle = BorderStyle.FixedSingle;
        //                break;
        //        }
        //    }
        //}

        public void SetLael(int i, string setdata)
        {
            if (i == 5)
            {
                label5.Text = setdata;
                label5.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (i == 6)
            {
                label6.Text = setdata;
                label6.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (i == 7)
            {
                label7.Text = setdata;
                label7.BorderStyle = BorderStyle.FixedSingle;
            }
            label1.Text = "选中要修改的按键";
        }

        void label5_Click(object sender, EventArgs e)
        {
            ChangeKeyKind = 1;
            KeyChangeReady = 1;
            label1.Text = "请按键";
            label5.BorderStyle =BorderStyle.Fixed3D;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label7.BorderStyle = BorderStyle.FixedSingle;
        }

        

      
       

      
    }
}
