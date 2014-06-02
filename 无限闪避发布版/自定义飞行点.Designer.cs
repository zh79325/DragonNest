using System.Windows.Forms;
namespace 无限闪避
{
    partial class 自定义飞行点
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            
            if (save == 1)
            {
                if (MessageBox.Show("未保存是否继续", "注意", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            ccf.cf = 1;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.传送点名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X坐标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y坐标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除巢穴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.传送点名称,
            this.X坐标,
            this.Y坐标});
            this.dataGridView1.Location = new System.Drawing.Point(7, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(507, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // 传送点名称
            // 
            this.传送点名称.HeaderText = "Column1";
            this.传送点名称.Name = "传送点名称";
            // 
            // X坐标
            // 
            this.X坐标.HeaderText = "Column1";
            this.X坐标.Name = "X坐标";
            // 
            // Y坐标
            // 
            this.Y坐标.HeaderText = "Column1";
            this.Y坐标.Name = "Y坐标";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "增加新副本";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "副本名称";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "增加传送点";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(386, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.增加ToolStripMenuItem,
            this.删除巢穴ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 92);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除ToolStripMenuItem.Text = "删除传送点";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 增加ToolStripMenuItem
            // 
            this.增加ToolStripMenuItem.Name = "增加ToolStripMenuItem";
            this.增加ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.增加ToolStripMenuItem.Text = "增加新传送点";
            this.增加ToolStripMenuItem.Click += new System.EventHandler(this.增加ToolStripMenuItem_Click);
            // 
            // 删除巢穴ToolStripMenuItem
            // 
            this.删除巢穴ToolStripMenuItem.Name = "删除巢穴ToolStripMenuItem";
            this.删除巢穴ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除巢穴ToolStripMenuItem.Text = "删除巢穴";
            // 
            // 自定义飞行点
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(526, 283);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(542, 321);
            this.Name = "自定义飞行点";
            this.Text = "自定义飞行点";
            this.Load += new System.EventHandler(this.自定义飞行点_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 传送点名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn X坐标;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y坐标;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private ToolStripMenuItem 删除巢穴ToolStripMenuItem;
    }
}