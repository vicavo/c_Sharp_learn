namespace Student_MI
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pbTime = new System.Windows.Forms.ProgressBar();
            this.lb_btnLogin = new System.Windows.Forms.Label();
            this.lb_brnExit = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUser.Location = new System.Drawing.Point(594, 299);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(220, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(594, 350);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(220, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // pbTime
            // 
            this.pbTime.Location = new System.Drawing.Point(173, 473);
            this.pbTime.Name = "pbTime";
            this.pbTime.Size = new System.Drawing.Size(674, 21);
            this.pbTime.TabIndex = 4;
            // 
            // lb_btnLogin
            // 
            this.lb_btnLogin.AutoSize = true;
            this.lb_btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.lb_btnLogin.Location = new System.Drawing.Point(599, 426);
            this.lb_btnLogin.Name = "lb_btnLogin";
            this.lb_btnLogin.Size = new System.Drawing.Size(52, 26);
            this.lb_btnLogin.TabIndex = 5;
            this.lb_btnLogin.Text = "               \r\n               ";
            this.lb_btnLogin.Click += new System.EventHandler(this.lb_btnLogin_Click);
            this.lb_btnLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_btnLogin_MouseMove);
            // 
            // lb_brnExit
            // 
            this.lb_brnExit.AutoSize = true;
            this.lb_brnExit.BackColor = System.Drawing.Color.Transparent;
            this.lb_brnExit.Location = new System.Drawing.Point(727, 426);
            this.lb_brnExit.Name = "lb_brnExit";
            this.lb_brnExit.Size = new System.Drawing.Size(52, 26);
            this.lb_brnExit.TabIndex = 5;
            this.lb_brnExit.Text = "               \r\n               ";
            this.lb_brnExit.Click += new System.EventHandler(this.lb_brnExit_Click);
            this.lb_brnExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_brnExit_MouseMove);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(-50, 638);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(51, 28);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(-52, 612);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1005, 670);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lb_brnExit);
            this.Controls.Add(this.lb_btnLogin);
            this.Controls.Add(this.pbTime);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ProgressBar pbTime;
        private System.Windows.Forms.Label lb_btnLogin;
        private System.Windows.Forms.Label lb_brnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
    }
}

