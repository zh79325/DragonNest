using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 无限闪避
{
    public partial class Input : Form
    {
        public string name="";
        public Input()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
        }

        private void Input_Load(object sender, EventArgs e)
        {

            
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
