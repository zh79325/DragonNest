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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
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
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.checkbox1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "移动加速";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(180, 12);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(47, 16);
            this.radioButton5.TabIndex = 7;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "学者";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
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
            this.menuStrip1.Size = new System.Drawing.Size(579, 24);
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
            this.toolStripMenuItem2.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem2.Text = "游戏";
            // 
            // 副本选择ToolStripMenuItem
            // 
            this.副本选择ToolStripMenuItem.Name = "副本选择ToolStripMenuItem";
            this.副本选择ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.副本选择ToolStripMenuItem.Text = "副本选择";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中速ToolStripMenuItem,
            this.高速ToolStripMenuItem,
            this.神速ToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem3.Text = "加速选项";
            // 
            // 中速ToolStripMenuItem
            // 
            this.中速ToolStripMenuItem.Name = "中速ToolStripMenuItem";
            this.中速ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.中速ToolStripMenuItem.Text = "中速";
            this.中速ToolStripMenuItem.ToolTipText = "1500移动速度";
            this.中速ToolStripMenuItem.Click += new System.EventHandler(this.中速ToolStripMenuItem_Click);
            // 
            // 高速ToolStripMenuItem
            // 
            this.高速ToolStripMenuItem.Name = "高速ToolStripMenuItem";
            this.高速ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.高速ToolStripMenuItem.Text = "高速";
            this.高速ToolStripMenuItem.ToolTipText = "2500移动速度";
            this.高速ToolStripMenuItem.Click += new System.EventHandler(this.高速ToolStripMenuItem_Click);
            // 
            // 神速ToolStripMenuItem
            // 
            this.神速ToolStripMenuItem.Name = "神速ToolStripMenuItem";
            this.神速ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
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
            this.瞬移距离ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.瞬移距离ToolStripMenuItem.Text = "瞬移距离";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem6.Text = "15";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(88, 22);
            this.toolStripMenuItem7.Text = "20";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(88, 22);
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
            this.自定义功能ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.自定义功能ToolStripMenuItem.Text = "自定义功能";
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // 键位修改ToolStripMenuItem
            // 
            this.键位修改ToolStripMenuItem.Name = "键位修改ToolStripMenuItem";
            this.键位修改ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.键位修改ToolStripMenuItem.Text = "键位修改";
            this.键位修改ToolStripMenuItem.Click += new System.EventHandler(this.键位修改ToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem4.Text = "自定义飞行";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click_1);
            // 
            // 新增飞行点ToolStripMenuItem
            // 
            this.新增飞行点ToolStripMenuItem.Name = "新增飞行点ToolStripMenuItem";
            this.新增飞行点ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
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
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用帮助ToolStripMenuItem
            // 
            this.使用帮助ToolStripMenuItem.Name = "使用帮助ToolStripMenuItem";
            this.使用帮助ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.使用帮助ToolStripMenuItem.Text = "使用帮助";
            this.使用帮助ToolStripMenuItem.Click += new System.EventHandler(this.使用帮助ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem1.Text = "人物信息";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 天启巢穴帮助ToolStripMenuItem
            // 
            this.天启巢穴帮助ToolStripMenuItem.Name = "天启巢穴帮助ToolStripMenuItem";
            this.天启巢穴帮助ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
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
            this.groupBox2.Size = new System.Drawing.Size(229, 100);
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
            // dataGridView1
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(536, 158);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "键";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Z";
            this.Column4.Name = "Column4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "导入坐标";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(248, 110);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(96, 16);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "使用坐标文件";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(395, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "记录坐标";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(395, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "导出坐标";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "坐标";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(395, 154);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(395, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 19;
            // 
            // 无限闪避
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(579, 366);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "无限闪避";
            this.Text = "龙之谷辅助";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.TextBox textBox1;

    }
}

