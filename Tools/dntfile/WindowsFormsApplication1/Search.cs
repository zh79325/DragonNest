using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Search : Form
    {
        int searchedindex = -1;
        string searchedtext = "";
        public Search(Form1 father)
        {
            this.father = father;
            InitializeComponent();
            searchedindex = 0;
        }
        public Form1 father;
        private void Search_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            for (int i = 0; i < father.mygridview.Columns.Count;i++ )
            {
                string title = father.mygridview.Columns[i].HeaderText;
                this.dataGridView1.Columns.Add(title, title);
                
            }

            for (int i = 0; i < father.mygridview.Columns.Count; i++)
            {

                this.dataGridView1[0, i].Value = "不变";
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string searchtext = textBox1.Text.Trim();
            if(!string.IsNullOrEmpty(searchtext))
            {
                if(searchedtext!=searchtext)
                {
                     searchedtext=searchtext;
                    searchedindex=0;
                }
                int k = 0;
                for(int i=searchedindex+1;i!=searchedindex;)
                {
                    if (i == father.mygridview.Rows.Count)
                    {
                        i = 0;
                    }
                    k++;
                    if (k >= father.mygridview.Rows.Count)
                    {
                        MessageBox.Show("没有找到");
                        break;
                    }
                    if (father.mygridview.Rows[i].HeaderCell.Value!=null&&((string)father.mygridview.Rows[i].HeaderCell.Value).ToUpper().IndexOf(searchtext.ToUpper()) >= 0)
                     {
                         searchedindex = i;
                         if (father.mygridview.SelectedRows.Count>0)
                         father.mygridview.SelectedRows[0].Selected = false;
                        
                         father.mygridview.Rows[i].Selected = true;
                         father.mygridview.FirstDisplayedScrollingRowIndex = i;
                         break;
                     }
                     i = (i+1);
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchtext = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchtext))
            {
                if (searchedtext != searchtext)
                {
                    searchedtext = searchtext;
                    searchedindex = 0;
                }
                int k = 0;
                for (int i = searchedindex - 1; ; )
                {
                    if (i < 0)
                    {
                        i = father.mygridview.Rows.Count - 1;
                    }
                    k++;
                    if (k >= father.mygridview.Rows.Count)
                    {
                        MessageBox.Show("没有找到");
                        break;
                    }
                    if (father.mygridview.Rows[i].HeaderCell.Value != null && ((string)father.mygridview.Rows[i].HeaderCell.Value).ToUpper().IndexOf(searchtext.ToUpper()) >= 0)
                    {
                        searchedindex = i;
                        if (father.mygridview.SelectedRows.Count > 0)
                            father.mygridview.SelectedRows[0].Selected = false;

                        father.mygridview.Rows[i].Selected = true;
                        father.mygridview.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                    i = i - 1;
                   
                }

            }
        }
    }
}
