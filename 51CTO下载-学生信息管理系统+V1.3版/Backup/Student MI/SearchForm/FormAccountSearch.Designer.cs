namespace Student_MI.SearchForm
{
    partial class FormAccountSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnCha = new System.Windows.Forms.Button();
            this.LvAccount = new System.Windows.Forms.ListView();
            this.username = new System.Windows.Forms.ColumnHeader();
            this.password = new System.Windows.Forms.ColumnHeader();
            this.type = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "按用户账号查询:";
            // 
            // txtAccount
            // 
            this.txtAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccount.Location = new System.Drawing.Point(111, 12);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(169, 21);
            this.txtAccount.TabIndex = 1;
            // 
            // btnCha
            // 
            this.btnCha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCha.Location = new System.Drawing.Point(286, 12);
            this.btnCha.Name = "btnCha";
            this.btnCha.Size = new System.Drawing.Size(63, 23);
            this.btnCha.TabIndex = 2;
            this.btnCha.Text = "查询";
            this.btnCha.UseVisualStyleBackColor = true;
            this.btnCha.Click += new System.EventHandler(this.btnCha_Click);
            // 
            // LvAccount
            // 
            this.LvAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.username,
            this.password,
            this.type});
            this.LvAccount.Location = new System.Drawing.Point(12, 41);
            this.LvAccount.Name = "LvAccount";
            this.LvAccount.Size = new System.Drawing.Size(337, 134);
            this.LvAccount.TabIndex = 3;
            this.LvAccount.UseCompatibleStateImageBehavior = false;
            this.LvAccount.View = System.Windows.Forms.View.Details;
            // 
            // username
            // 
            this.username.Text = "账户";
            this.username.Width = 114;
            // 
            // password
            // 
            this.password.Text = "密码";
            this.password.Width = 112;
            // 
            // type
            // 
            this.type.Text = "类型";
            this.type.Width = 102;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(274, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAccountSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(361, 216);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.LvAccount);
            this.Controls.Add(this.btnCha);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormAccountSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生账户查询";
            this.Load += new System.EventHandler(this.FormAccountSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnCha;
        private System.Windows.Forms.ListView LvAccount;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.Button btnClose;
    }
}