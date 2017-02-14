namespace Student_MI.SearchForm
{
    partial class FormStudentSearch
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
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.LvStudent = new System.Windows.Forms.ListView();
            this.SNumber = new System.Windows.Forms.ColumnHeader();
            this.SName = new System.Windows.Forms.ColumnHeader();
            this.SSex = new System.Windows.Forms.ColumnHeader();
            this.SAge = new System.Windows.Forms.ColumnHeader();
            this.SEmail = new System.Windows.Forms.ColumnHeader();
            this.btnCha = new System.Windows.Forms.Button();
            this.btnColse = new System.Windows.Forms.Button();
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
            this.label1.Text = "按用户名字查询:";
            // 
            // txtStudent
            // 
            this.txtStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudent.Location = new System.Drawing.Point(111, 12);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(157, 21);
            this.txtStudent.TabIndex = 1;
            // 
            // LvStudent
            // 
            this.LvStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LvStudent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SNumber,
            this.SName,
            this.SSex,
            this.SAge,
            this.SEmail});
            this.LvStudent.Location = new System.Drawing.Point(10, 39);
            this.LvStudent.Name = "LvStudent";
            this.LvStudent.Size = new System.Drawing.Size(339, 136);
            this.LvStudent.TabIndex = 2;
            this.LvStudent.UseCompatibleStateImageBehavior = false;
            this.LvStudent.View = System.Windows.Forms.View.Details;
            // 
            // SNumber
            // 
            this.SNumber.Text = "学号";
            this.SNumber.Width = 51;
            // 
            // SName
            // 
            this.SName.Text = "姓名";
            // 
            // SSex
            // 
            this.SSex.Text = "性别";
            // 
            // SAge
            // 
            this.SAge.Text = "年龄";
            this.SAge.Width = 46;
            // 
            // SEmail
            // 
            this.SEmail.Text = "邮箱";
            this.SEmail.Width = 95;
            // 
            // btnCha
            // 
            this.btnCha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCha.Location = new System.Drawing.Point(274, 10);
            this.btnCha.Name = "btnCha";
            this.btnCha.Size = new System.Drawing.Size(75, 23);
            this.btnCha.TabIndex = 3;
            this.btnCha.Text = "查询";
            this.btnCha.UseVisualStyleBackColor = true;
            this.btnCha.Click += new System.EventHandler(this.btnCha_Click);
            // 
            // btnColse
            // 
            this.btnColse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColse.Location = new System.Drawing.Point(274, 181);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(75, 23);
            this.btnColse.TabIndex = 4;
            this.btnColse.Text = "关闭";
            this.btnColse.UseVisualStyleBackColor = true;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // FormStudentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(361, 216);
            this.Controls.Add(this.btnColse);
            this.Controls.Add(this.btnCha);
            this.Controls.Add(this.LvStudent);
            this.Controls.Add(this.txtStudent);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormStudentSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 学生信息查询";
            this.Load += new System.EventHandler(this.FormStudentSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.ListView LvStudent;
        private System.Windows.Forms.ColumnHeader SNumber;
        private System.Windows.Forms.ColumnHeader SName;
        private System.Windows.Forms.ColumnHeader SSex;
        private System.Windows.Forms.ColumnHeader SAge;
        private System.Windows.Forms.Button btnCha;
        private System.Windows.Forms.Button btnColse;
        private System.Windows.Forms.ColumnHeader SEmail;
    }
}