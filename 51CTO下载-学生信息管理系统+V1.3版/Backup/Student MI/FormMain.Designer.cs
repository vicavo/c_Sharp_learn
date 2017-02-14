namespace Student_MI
{
    partial class FormMain
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStudentInfoManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCourseInfoManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScoreInfoManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountInfoManage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.tsbStudentInfoManage = new System.Windows.Forms.ToolStripButton();
            this.tsbCourseInfoManage = new System.Windows.Forms.ToolStripButton();
            this.tsbScoreInfoManage = new System.Windows.Forms.ToolStripButton();
            this.tsbAccountInfoManage = new System.Windows.Forms.ToolStripButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMenu.SuspendLayout();
            this.tsTools.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManage,
            this.tsmiWindows,
            this.tsmiHelp});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(784, 24);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsmiManage
            // 
            this.tsmiManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStudentInfoManage,
            this.tsmiCourseInfoManage,
            this.tsmiScoreInfoManage,
            this.tsmiAccountInfoManage,
            this.toolStripMenuItem1,
            this.tsmiExit});
            this.tsmiManage.Name = "tsmiManage";
            this.tsmiManage.Size = new System.Drawing.Size(59, 20);
            this.tsmiManage.Text = "管理(&G)";
            // 
            // tsmiStudentInfoManage
            // 
            this.tsmiStudentInfoManage.Name = "tsmiStudentInfoManage";
            this.tsmiStudentInfoManage.Size = new System.Drawing.Size(162, 22);
            this.tsmiStudentInfoManage.Text = "学生信息管理(&X)";
            this.tsmiStudentInfoManage.Click += new System.EventHandler(this.tsmiStudentInfoManage_Click);
            // 
            // tsmiCourseInfoManage
            // 
            this.tsmiCourseInfoManage.Name = "tsmiCourseInfoManage";
            this.tsmiCourseInfoManage.Size = new System.Drawing.Size(162, 22);
            this.tsmiCourseInfoManage.Text = "课程信息管理(&K)";
            this.tsmiCourseInfoManage.Click += new System.EventHandler(this.tsmiCourseInfoManage_Click);
            // 
            // tsmiScoreInfoManage
            // 
            this.tsmiScoreInfoManage.Name = "tsmiScoreInfoManage";
            this.tsmiScoreInfoManage.Size = new System.Drawing.Size(162, 22);
            this.tsmiScoreInfoManage.Text = "成绩信息管理(&C)";
            this.tsmiScoreInfoManage.Click += new System.EventHandler(this.tsmiScoreInfoManage_Click);
            // 
            // tsmiAccountInfoManage
            // 
            this.tsmiAccountInfoManage.Name = "tsmiAccountInfoManage";
            this.tsmiAccountInfoManage.Size = new System.Drawing.Size(162, 22);
            this.tsmiAccountInfoManage.Text = "账户信息管理(&Z)";
            this.tsmiAccountInfoManage.Click += new System.EventHandler(this.tsmiAccountInfoManage_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(162, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiWindows
            // 
            this.tsmiWindows.Name = "tsmiWindows";
            this.tsmiWindows.Size = new System.Drawing.Size(59, 20);
            this.tsmiWindows.Text = "窗口(&C)";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(58, 20);
            this.tsmiHelp.Text = "帮助(&B)";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmiAbout.Text = "关于(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tsTools
            // 
            this.tsTools.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStudentInfoManage,
            this.tsbCourseInfoManage,
            this.tsbScoreInfoManage,
            this.tsbAccountInfoManage});
            this.tsTools.Location = new System.Drawing.Point(0, 24);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(784, 39);
            this.tsTools.TabIndex = 2;
            this.tsTools.Text = "toolStrip1";
            // 
            // tsbStudentInfoManage
            // 
            this.tsbStudentInfoManage.Image = global::Student_MI.Properties.Resources.newStu;
            this.tsbStudentInfoManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbStudentInfoManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStudentInfoManage.Name = "tsbStudentInfoManage";
            this.tsbStudentInfoManage.Size = new System.Drawing.Size(115, 36);
            this.tsbStudentInfoManage.Text = "学生信息管理";
            this.tsbStudentInfoManage.Click += new System.EventHandler(this.tsbStudentInfoManage_Click);
            // 
            // tsbCourseInfoManage
            // 
            this.tsbCourseInfoManage.Image = global::Student_MI.Properties.Resources.newUser;
            this.tsbCourseInfoManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCourseInfoManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCourseInfoManage.Name = "tsbCourseInfoManage";
            this.tsbCourseInfoManage.Size = new System.Drawing.Size(115, 36);
            this.tsbCourseInfoManage.Text = "课程信息管理";
            this.tsbCourseInfoManage.Click += new System.EventHandler(this.tsbCourseInfoManage_Click);
            // 
            // tsbScoreInfoManage
            // 
            this.tsbScoreInfoManage.Image = global::Student_MI.Properties.Resources.question;
            this.tsbScoreInfoManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbScoreInfoManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScoreInfoManage.Name = "tsbScoreInfoManage";
            this.tsbScoreInfoManage.Size = new System.Drawing.Size(115, 36);
            this.tsbScoreInfoManage.Text = "成绩信息管理";
            this.tsbScoreInfoManage.Click += new System.EventHandler(this.tsbScoreInfoManage_Click);
            // 
            // tsbAccountInfoManage
            // 
            this.tsbAccountInfoManage.Image = global::Student_MI.Properties.Resources.searchTeacher;
            this.tsbAccountInfoManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAccountInfoManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAccountInfoManage.Name = "tsbAccountInfoManage";
            this.tsbAccountInfoManage.Size = new System.Drawing.Size(115, 36);
            this.tsbAccountInfoManage.Text = "账户信息管理";
            this.tsbAccountInfoManage.Click += new System.EventHandler(this.tsbAccountInfoManage_Click);
            // 
            // ssMain
            // 
            this.ssMain.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInfo,
            this.lbTime});
            this.ssMain.Location = new System.Drawing.Point(0, 520);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(784, 22);
            this.ssMain.TabIndex = 3;
            this.ssMain.Text = "statusStrip1";
            // 
            // lbInfo
            // 
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(46, 17);
            this.lbInfo.Text = "登录人:";
            // 
            // lbTime
            // 
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(58, 17);
            this.lbTime.Text = "当前时间:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 542);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.msMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学员管理系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiStudentInfoManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCourseInfoManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiScoreInfoManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountInfoManage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindows;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripStatusLabel lbInfo;
        private System.Windows.Forms.ToolStripStatusLabel lbTime;
        private System.Windows.Forms.ToolStripButton tsbStudentInfoManage;
        private System.Windows.Forms.ToolStripButton tsbCourseInfoManage;
        private System.Windows.Forms.ToolStripButton tsbScoreInfoManage;
        private System.Windows.Forms.ToolStripButton tsbAccountInfoManage;
    }
}