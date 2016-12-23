namespace LTC_Notify
{
    partial class FloatWnd
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
            this.Price_Buy = new System.Windows.Forms.Label();
            this.Price_Sell = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateTime = new System.Windows.Forms.Label();
            this.Price_Last = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Price_Buy
            // 
            this.Price_Buy.AutoSize = true;
            this.Price_Buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price_Buy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Price_Buy.Location = new System.Drawing.Point(0, 2);
            this.Price_Buy.Name = "Price_Buy";
            this.Price_Buy.Size = new System.Drawing.Size(86, 20);
            this.Price_Buy.TabIndex = 0;
            this.Price_Buy.Text = "B: 000.00";
            // 
            // Price_Sell
            // 
            this.Price_Sell.AutoSize = true;
            this.Price_Sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price_Sell.ForeColor = System.Drawing.Color.Green;
            this.Price_Sell.Location = new System.Drawing.Point(94, 2);
            this.Price_Sell.Name = "Price_Sell";
            this.Price_Sell.Size = new System.Drawing.Size(86, 20);
            this.Price_Sell.TabIndex = 1;
            this.Price_Sell.Text = "S: 000.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(83, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "/";
            // 
            // UpdateTime
            // 
            this.UpdateTime.AutoSize = true;
            this.UpdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateTime.ForeColor = System.Drawing.Color.Olive;
            this.UpdateTime.Location = new System.Drawing.Point(98, 23);
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.Size = new System.Drawing.Size(55, 15);
            this.UpdateTime.TabIndex = 3;
            this.UpdateTime.Text = "12:13:15";
            // 
            // Price_Last
            // 
            this.Price_Last.AutoSize = true;
            this.Price_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price_Last.ForeColor = System.Drawing.Color.Teal;
            this.Price_Last.Location = new System.Drawing.Point(1, 20);
            this.Price_Last.Name = "Price_Last";
            this.Price_Last.Size = new System.Drawing.Size(84, 20);
            this.Price_Last.TabIndex = 0;
            this.Price_Last.Text = "L: 000.00";
            // 
            // FloatWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(179, 42);
            this.Controls.Add(this.UpdateTime);
            this.Controls.Add(this.Price_Sell);
            this.Controls.Add(this.Price_Last);
            this.Controls.Add(this.Price_Buy);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FloatWnd";
            this.Text = "FloatWnd";
            this.Load += new System.EventHandler(this.FloatWnd_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FloatWnd_MouseDoubleClick);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FloatWnd_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Price_Buy;
        private System.Windows.Forms.Label Price_Sell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UpdateTime;
        private System.Windows.Forms.Label Price_Last;
    }
}