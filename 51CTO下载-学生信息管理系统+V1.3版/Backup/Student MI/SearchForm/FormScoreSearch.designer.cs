namespace Student_MI
{
    partial class FormScoreManage
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvScore = new System.Windows.Forms.ListView();
            this.chSNumber = new System.Windows.Forms.ColumnHeader();
            this.chSName = new System.Windows.Forms.ColumnHeader();
            this.clCourse = new System.Windows.Forms.ColumnHeader();
            this.clScore = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(111, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 21);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(274, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvScore
            // 
            this.lvScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvScore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSNumber,
            this.chSName,
            this.clCourse,
            this.clScore});
            this.lvScore.FullRowSelect = true;
            this.lvScore.GridLines = true;
            this.lvScore.Location = new System.Drawing.Point(12, 39);
            this.lvScore.MultiSelect = false;
            this.lvScore.Name = "lvScore";
            this.lvScore.Size = new System.Drawing.Size(337, 136);
            this.lvScore.TabIndex = 2;
            this.lvScore.UseCompatibleStateImageBehavior = false;
            this.lvScore.View = System.Windows.Forms.View.Details;
            // 
            // chSNumber
            // 
            this.chSNumber.Text = "学号";
            this.chSNumber.Width = 65;
            // 
            // chSName
            // 
            this.chSName.Text = "姓名";
            this.chSName.Width = 87;
            // 
            // clCourse
            // 
            this.clCourse.Text = "科目";
            this.clCourse.Width = 83;
            // 
            // clScore
            // 
            this.clScore.Text = "成绩";
            this.clScore.Width = 84;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(274, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbSearch.Location = new System.Drawing.Point(10, 15);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(95, 12);
            this.lbSearch.TabIndex = 4;
            this.lbSearch.Text = "按姓名模糊查询:";
            // 
            // FormScoreManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(361, 216);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvScore);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.MaximizeBox = false;
            this.Name = "FormScoreManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生成绩查询";
            this.Load += new System.EventHandler(this.FormScoreManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvScore;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.ColumnHeader chSNumber;
        private System.Windows.Forms.ColumnHeader chSName;
        private System.Windows.Forms.ColumnHeader clCourse;
        private System.Windows.Forms.ColumnHeader clScore;
    }
}