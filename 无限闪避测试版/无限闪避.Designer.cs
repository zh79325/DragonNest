namespace hook1
{
    partial class 无限闪避
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            mykeyboardhook.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox1 = new System.Windows.Forms.CheckBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.副本选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.中速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.神速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.瞬移距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.键位修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.新增飞行点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.天启巢穴帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "移动加速";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkbox1
            // 
            this.checkbox1.AutoSize = true;
            this.checkbox1.Location = new System.Drawing.Point(6, 20);
            this.checkbox1.Name = "checkbox1";
            this.checkbox1.Size = new System.Drawing.Size(48, 16);
            this.checkbox1.TabIndex = 6;
            this.checkbox1.Text = "加速";
            this.checkbox1.UseVisualStyleBackColor = true;
            this.checkbox1.CheckedChanged += new System.EventHandler(this.checkbox1_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(126, 34);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "弓箭";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(126, 12);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "法师";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(73, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "牧师";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(73, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "战士";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.自定义功能ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(223, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.副本选择ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.瞬移距离ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem2.Text = "游戏";
            // 
            // 副本选择ToolStripMenuItem
            // 
            this.副本选择ToolStripMenuItem.Name = "副本选择ToolStripMenuItem";
            this.副本选择ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.副本选择ToolStripMenuItem.Text = "副本选择";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中速ToolStripMenuItem,
            this.高速ToolStripMenuItem,
            this.神速ToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem3.Text = "加速选项";
            // 
            // 中速ToolStripMenuItem
            // 
            this.中速ToolStripMenuItem.Name = "中速ToolStripMenuItem";
            this.中速ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.中速ToolStripMenuItem.Text = "中速";
            this.中速ToolStripMenuItem.ToolTipText = "1500移动速度";
            this.中速ToolStripMenuItem.Click += new System.EventHandler(this.中速ToolStripMenuItem_Click);
            // 
            // 高速ToolStripMenuItem
            // 
            this.高速ToolStripMenuItem.Name = "高速ToolStripMenuItem";
            this.高速ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.高速ToolStripMenuItem.Text = "高速";
            this.高速ToolStripMenuItem.ToolTipText = "2500移动速度";
            this.高速ToolStripMenuItem.Click += new System.EventHandler(this.高速ToolStripMenuItem_Click);
            // 
            // 神速ToolStripMenuItem
            // 
            this.神速ToolStripMenuItem.Name = "神速ToolStripMenuItem";
            this.神速ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.神速ToolStripMenuItem.Text = "神速";
            this.神速ToolStripMenuItem.ToolTipText = "5000移动速度";
            this.神速ToolStripMenuItem.Click += new System.EventHandler(this.神速ToolStripMenuItem_Click);
            // 
            // 瞬移距离ToolStripMenuItem
            // 
            this.瞬移距离ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.瞬移距离ToolStripMenuItem.Name = "瞬移距离ToolStripMenuItem";
            this.瞬移距离ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.瞬移距离ToolStripMenuItem.Text = "瞬移距离";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem6.Text = "15";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem7.Text = "20";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem8.Text = "50";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // 自定义功能ToolStripMenuItem
            // 
            this.自定义功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新ToolStripMenuItem,
            this.键位修改ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.新增飞行点ToolStripMenuItem});
            this.自定义功能ToolStripMenuItem.Name = "自定义功能ToolStripMenuItem";
            this.自定义功能ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.自定义功能ToolStripMenuItem.Text = "自定义功能";
            // 
            // 键位修改ToolStripMenuItem
            // 
            this.键位修改ToolStripMenuItem.Name = "键位修改ToolStripMenuItem";
            this.键位修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.键位修改ToolStripMenuItem.Text = "键位修改";
            this.键位修改ToolStripMenuItem.Click += new System.EventHandler(this.键位修改ToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "自定义飞行";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click_1);
            // 
            // 新增飞行点ToolStripMenuItem
            // 
            this.新增飞行点ToolStripMenuItem.Name = "新增飞行点ToolStripMenuItem";
            this.新增飞行点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增飞行点ToolStripMenuItem.Text = "飞行点设置";
            this.新增飞行点ToolStripMenuItem.Click += new System.EventHandler(this.新增飞行点ToolStripMenuItem_Click_1);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用帮助ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.天启巢穴帮助ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用帮助ToolStripMenuItem
            // 
            this.使用帮助ToolStripMenuItem.Name = "使用帮助ToolStripMenuItem";
            this.使用帮助ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.使用帮助ToolStripMenuItem.Text = "使用帮助";
            this.使用帮助ToolStripMenuItem.Click += new System.EventHandler(this.使用帮助ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "人物信息";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 天启巢穴帮助ToolStripMenuItem
            // 
            this.天启巢穴帮助ToolStripMenuItem.Name = "天启巢穴帮助ToolStripMenuItem";
            this.天启巢穴帮助ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.天启巢穴帮助ToolStripMenuItem.Text = "天启巢穴帮助";
            this.天启巢穴帮助ToolStripMenuItem.Click += new System.EventHandler(this.天启巢穴帮助ToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "瞬移";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "幽灵坐标",
            "天启怕光死神钥匙",
            "天启五只黑烟钥匙",
            "天启巨大魔灵钥匙",
            "天启铁食人魔钥匙",
            "天启骷髅牛怪钥匙",
            "天启犀牛船长钥匙",
            "蜘蛛",
            "宝箱"});
            this.comboBox1.Location = new System.Drawing.Point(6, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 20);
            this.comboBox1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "无限瞬移";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "开启前后瞬移";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // 无限闪避
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(223, 196);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(239, 234);
            this.Name = "无限闪避";
            this.Text = "龙之谷辅助";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkbox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 天启巢穴帮助ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 副本选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 中速ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高速ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 神速ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 自定义功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 键位修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 新增飞行点ToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem 瞬移距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;

    }
}

