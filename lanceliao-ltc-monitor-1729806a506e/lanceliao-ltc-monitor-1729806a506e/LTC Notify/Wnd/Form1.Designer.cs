namespace LTC_Notify
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Result_Vol = new System.Windows.Forms.Label();
            this.Result_Last = new System.Windows.Forms.Label();
            this.Result_Low = new System.Windows.Forms.Label();
            this.Result_Sell = new System.Windows.Forms.Label();
            this.Result_High = new System.Windows.Forms.Label();
            this.Result_Buy = new System.Windows.Forms.Label();
            this.Result_UpdateTime = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CFG_NotifyBuyPrice = new System.Windows.Forms.TextBox();
            this.CFG_Interval = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label26 = new System.Windows.Forms.Label();
            this.CFG_NotifySellPrice = new System.Windows.Forms.TextBox();
            this.CFG_PriceDeviation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Status_NextTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_LastErr = new System.Windows.Forms.Label();
            this.Status_LastTime = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.onTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "更新时间:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "买入价：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 82);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "卖出价:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 110);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "最后成交价:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.Result_Vol);
            this.groupBox2.Controls.Add(this.Result_Last);
            this.groupBox2.Controls.Add(this.Result_Low);
            this.groupBox2.Controls.Add(this.Result_Sell);
            this.groupBox2.Controls.Add(this.Result_High);
            this.groupBox2.Controls.Add(this.Result_Buy);
            this.groupBox2.Controls.Add(this.Result_UpdateTime);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(13, 133);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(516, 167);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "记录此条";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(19, 82);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 17);
            this.label25.TabIndex = 6;
            this.label25.Text = "最低价:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 138);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 17);
            this.label17.TabIndex = 6;
            this.label17.Text = "成交量:";
            // 
            // Result_Vol
            // 
            this.Result_Vol.AutoSize = true;
            this.Result_Vol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Vol.ForeColor = System.Drawing.Color.DarkGreen;
            this.Result_Vol.Location = new System.Drawing.Point(103, 138);
            this.Result_Vol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_Vol.Name = "Result_Vol";
            this.Result_Vol.Size = new System.Drawing.Size(58, 17);
            this.Result_Vol.TabIndex = 7;
            this.Result_Vol.Text = "未查询:";
            // 
            // Result_Last
            // 
            this.Result_Last.AutoSize = true;
            this.Result_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Last.ForeColor = System.Drawing.Color.Red;
            this.Result_Last.Location = new System.Drawing.Point(103, 110);
            this.Result_Last.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_Last.Name = "Result_Last";
            this.Result_Last.Size = new System.Drawing.Size(58, 17);
            this.Result_Last.TabIndex = 7;
            this.Result_Last.Text = "未查询:";
            // 
            // Result_Low
            // 
            this.Result_Low.AutoSize = true;
            this.Result_Low.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Low.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Result_Low.Location = new System.Drawing.Point(103, 82);
            this.Result_Low.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_Low.Name = "Result_Low";
            this.Result_Low.Size = new System.Drawing.Size(58, 17);
            this.Result_Low.TabIndex = 7;
            this.Result_Low.Text = "未查询:";
            // 
            // Result_Sell
            // 
            this.Result_Sell.AutoSize = true;
            this.Result_Sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Sell.ForeColor = System.Drawing.Color.Green;
            this.Result_Sell.Location = new System.Drawing.Point(362, 78);
            this.Result_Sell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_Sell.Name = "Result_Sell";
            this.Result_Sell.Size = new System.Drawing.Size(76, 24);
            this.Result_Sell.TabIndex = 7;
            this.Result_Sell.Text = "未查询:";
            // 
            // Result_High
            // 
            this.Result_High.AutoSize = true;
            this.Result_High.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_High.ForeColor = System.Drawing.Color.Maroon;
            this.Result_High.Location = new System.Drawing.Point(103, 54);
            this.Result_High.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_High.Name = "Result_High";
            this.Result_High.Size = new System.Drawing.Size(58, 17);
            this.Result_High.TabIndex = 7;
            this.Result_High.Text = "未查询:";
            // 
            // Result_Buy
            // 
            this.Result_Buy.AutoSize = true;
            this.Result_Buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_Buy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Result_Buy.Location = new System.Drawing.Point(362, 50);
            this.Result_Buy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_Buy.Name = "Result_Buy";
            this.Result_Buy.Size = new System.Drawing.Size(76, 24);
            this.Result_Buy.TabIndex = 7;
            this.Result_Buy.Text = "未查询:";
            // 
            // Result_UpdateTime
            // 
            this.Result_UpdateTime.AutoSize = true;
            this.Result_UpdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_UpdateTime.ForeColor = System.Drawing.Color.Teal;
            this.Result_UpdateTime.Location = new System.Drawing.Point(103, 26);
            this.Result_UpdateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result_UpdateTime.Name = "Result_UpdateTime";
            this.Result_UpdateTime.Size = new System.Drawing.Size(58, 17);
            this.Result_UpdateTime.TabIndex = 7;
            this.Result_UpdateTime.Text = "未查询:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 54);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "最高价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "请求间隔:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 86);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "买入价提示:";
            // 
            // CFG_NotifyBuyPrice
            // 
            this.CFG_NotifyBuyPrice.Location = new System.Drawing.Point(111, 83);
            this.CFG_NotifyBuyPrice.Margin = new System.Windows.Forms.Padding(4);
            this.CFG_NotifyBuyPrice.Name = "CFG_NotifyBuyPrice";
            this.CFG_NotifyBuyPrice.Size = new System.Drawing.Size(176, 23);
            this.CFG_NotifyBuyPrice.TabIndex = 1;
            this.CFG_NotifyBuyPrice.Text = "164";
            // 
            // CFG_Interval
            // 
            this.CFG_Interval.Location = new System.Drawing.Point(111, 53);
            this.CFG_Interval.Margin = new System.Windows.Forms.Padding(4);
            this.CFG_Interval.Name = "CFG_Interval";
            this.CFG_Interval.Size = new System.Drawing.Size(176, 23);
            this.CFG_Interval.TabIndex = 1;
            this.CFG_Interval.Text = "1000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 138);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(291, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "毫秒(>1000ms)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.CFG_Interval);
            this.groupBox1.Controls.Add(this.CFG_NotifySellPrice);
            this.groupBox1.Controls.Add(this.CFG_NotifyBuyPrice);
            this.groupBox1.Controls.Add(this.CFG_PriceDeviation);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 313);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(516, 179);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(197, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "LTC";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(106, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "BTC";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label26.Location = new System.Drawing.Point(291, 86);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 17);
            this.label26.TabIndex = 3;
            this.label26.Text = "(*浮点数)";
            // 
            // CFG_NotifySellPrice
            // 
            this.CFG_NotifySellPrice.Location = new System.Drawing.Point(111, 113);
            this.CFG_NotifySellPrice.Margin = new System.Windows.Forms.Padding(4);
            this.CFG_NotifySellPrice.Name = "CFG_NotifySellPrice";
            this.CFG_NotifySellPrice.Size = new System.Drawing.Size(176, 23);
            this.CFG_NotifySellPrice.TabIndex = 1;
            this.CFG_NotifySellPrice.Text = "169";
            // 
            // CFG_PriceDeviation
            // 
            this.CFG_PriceDeviation.Location = new System.Drawing.Point(111, 143);
            this.CFG_PriceDeviation.Margin = new System.Windows.Forms.Padding(4);
            this.CFG_PriceDeviation.Name = "CFG_PriceDeviation";
            this.CFG_PriceDeviation.Size = new System.Drawing.Size(176, 23);
            this.CFG_PriceDeviation.TabIndex = 1;
            this.CFG_PriceDeviation.Text = "0.1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 116);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "卖出价提示:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 146);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "提示价容差:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "API类型:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.Status_NextTime);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Status_LastErr);
            this.groupBox3.Controls.Add(this.Status_LastTime);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(516, 114);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询状态:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 17);
            this.label14.TabIndex = 3;
            this.label14.Text = "下一次查询倒计时:";
            // 
            // Status_NextTime
            // 
            this.Status_NextTime.AutoSize = true;
            this.Status_NextTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_NextTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Status_NextTime.Location = new System.Drawing.Point(185, 80);
            this.Status_NextTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Status_NextTime.Name = "Status_NextTime";
            this.Status_NextTime.Size = new System.Drawing.Size(66, 24);
            this.Status_NextTime.TabIndex = 7;
            this.Status_NextTime.Text = "label4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "最后一次错误:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "最后请求时间：";
            // 
            // Status_LastErr
            // 
            this.Status_LastErr.AutoSize = true;
            this.Status_LastErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_LastErr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Status_LastErr.Location = new System.Drawing.Point(134, 56);
            this.Status_LastErr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Status_LastErr.Name = "Status_LastErr";
            this.Status_LastErr.Size = new System.Drawing.Size(42, 17);
            this.Status_LastErr.TabIndex = 6;
            this.Status_LastErr.Text = "None";
            // 
            // Status_LastTime
            // 
            this.Status_LastTime.AutoSize = true;
            this.Status_LastTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_LastTime.ForeColor = System.Drawing.Color.Teal;
            this.Status_LastTime.Location = new System.Drawing.Point(133, 28);
            this.Status_LastTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Status_LastTime.Name = "Status_LastTime";
            this.Status_LastTime.Size = new System.Drawing.Size(53, 17);
            this.Status_LastTime.TabIndex = 6;
            this.Status_LastTime.Text = "未查询";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Click to open";
            this.notifyIcon1.BalloonTipTitle = "LTC Monitor";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LTC Monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onTopToolStripMenuItem,
            this.floatToolStripMenuItem,
            this.setOnToolStripMenuItem,
            this.toolStripSeparator2,
            this.logToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 182);
            // 
            // onTopToolStripMenuItem
            // 
            this.onTopToolStripMenuItem.Name = "onTopToolStripMenuItem";
            this.onTopToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.onTopToolStripMenuItem.Text = "窗口置顶";
            this.onTopToolStripMenuItem.Click += new System.EventHandler(this.onTopToolStripMenuItem_Click);
            // 
            // floatToolStripMenuItem
            // 
            this.floatToolStripMenuItem.Checked = true;
            this.floatToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.floatToolStripMenuItem.Name = "floatToolStripMenuItem";
            this.floatToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.floatToolStripMenuItem.Text = "悬浮窗口";
            this.floatToolStripMenuItem.Click += new System.EventHandler(this.floatToolStripMenuItem_Click);
            // 
            // setOnToolStripMenuItem
            // 
            this.setOnToolStripMenuItem.Checked = true;
            this.setOnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setOnToolStripMenuItem.Name = "setOnToolStripMenuItem";
            this.setOnToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.setOnToolStripMenuItem.Text = "设置页面";
            this.setOnToolStripMenuItem.Click += new System.EventHandler(this.setOnToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.logToolStripMenuItem.Text = "记录此条";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.toolStripMenuItem1.Text = "退出";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.toolStripMenuItem2.Text = "关于";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(543, 504);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LTC Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CFG_NotifyBuyPrice;
        private System.Windows.Forms.TextBox CFG_Interval;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CFG_PriceDeviation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Status_NextTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Status_LastTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label Result_Vol;
        private System.Windows.Forms.Label Result_Last;
        private System.Windows.Forms.Label Result_Sell;
        private System.Windows.Forms.Label Result_Buy;
        private System.Windows.Forms.Label Result_UpdateTime;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label Result_Low;
        private System.Windows.Forms.Label Result_High;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox CFG_NotifySellPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Status_LastErr;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem onTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem floatToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

