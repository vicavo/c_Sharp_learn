namespace Student_MI
{
    partial class FormMenu
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
            this.lbMenu = new System.Windows.Forms.Label();
            this.btnStudentInfo = new System.Windows.Forms.Button();
            this.btnCourseInfo = new System.Windows.Forms.Button();
            this.btnStudentInfoManage = new System.Windows.Forms.Button();
            this.btnCourseInfoManage = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnLogOut = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMenu
            // 
            this.lbMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMenu.AutoSize = true;
            this.lbMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbMenu.Location = new System.Drawing.Point(12, 14);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(125, 12);
            this.lbMenu.TabIndex = 13;
            this.lbMenu.Text = "请选择你要使用的界面";
            // 
            // btnStudentInfo
            // 
            this.btnStudentInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStudentInfo.Location = new System.Drawing.Point(12, 39);
            this.btnStudentInfo.Name = "btnStudentInfo";
            this.btnStudentInfo.Size = new System.Drawing.Size(118, 23);
            this.btnStudentInfo.TabIndex = 6;
            this.btnStudentInfo.Text = "学生信息管理界面";
            this.btnStudentInfo.UseVisualStyleBackColor = true;
            this.btnStudentInfo.Click += new System.EventHandler(this.btnStudentInfo_Click);
            // 
            // btnCourseInfo
            // 
            this.btnCourseInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCourseInfo.Location = new System.Drawing.Point(137, 39);
            this.btnCourseInfo.Name = "btnCourseInfo";
            this.btnCourseInfo.Size = new System.Drawing.Size(119, 23);
            this.btnCourseInfo.TabIndex = 7;
            this.btnCourseInfo.Text = "课程信息管理界面";
            this.btnCourseInfo.UseVisualStyleBackColor = true;
            this.btnCourseInfo.Click += new System.EventHandler(this.btnCourseInfo_Click);
            // 
            // btnStudentInfoManage
            // 
            this.btnStudentInfoManage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStudentInfoManage.Location = new System.Drawing.Point(12, 68);
            this.btnStudentInfoManage.Name = "btnStudentInfoManage";
            this.btnStudentInfoManage.Size = new System.Drawing.Size(118, 23);
            this.btnStudentInfoManage.TabIndex = 8;
            this.btnStudentInfoManage.Text = "成绩信息管理界面";
            this.btnStudentInfoManage.UseVisualStyleBackColor = true;
            this.btnStudentInfoManage.Click += new System.EventHandler(this.btnStudentInfoManage_Click);
            // 
            // btnCourseInfoManage
            // 
            this.btnCourseInfoManage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCourseInfoManage.Location = new System.Drawing.Point(137, 68);
            this.btnCourseInfoManage.Name = "btnCourseInfoManage";
            this.btnCourseInfoManage.Size = new System.Drawing.Size(119, 23);
            this.btnCourseInfoManage.TabIndex = 9;
            this.btnCourseInfoManage.Text = "账户信息管理界面";
            this.btnCourseInfoManage.UseVisualStyleBackColor = true;
            this.btnCourseInfoManage.Click += new System.EventHandler(this.btnCourseInfoManage_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnModify.Location = new System.Drawing.Point(12, 97);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(118, 23);
            this.BtnModify.TabIndex = 10;
            this.BtnModify.Text = "密码修改";
            this.BtnModify.UseVisualStyleBackColor = true;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnLogOut.Location = new System.Drawing.Point(137, 97);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(119, 23);
            this.BtnLogOut.TabIndex = 11;
            this.BtnLogOut.Text = "注销登录";
            this.BtnLogOut.UseVisualStyleBackColor = true;
            this.BtnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.Location = new System.Drawing.Point(181, 131);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "退出系统";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(268, 162);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.BtnLogOut);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.btnCourseInfoManage);
            this.Controls.Add(this.btnStudentInfoManage);
            this.Controls.Add(this.btnCourseInfo);
            this.Controls.Add(this.btnStudentInfo);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Button btnStudentInfo;
        private System.Windows.Forms.Button btnCourseInfo;
        private System.Windows.Forms.Button btnStudentInfoManage;
        private System.Windows.Forms.Button btnCourseInfoManage;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnLogOut;
        private System.Windows.Forms.Button button7;
    }
}