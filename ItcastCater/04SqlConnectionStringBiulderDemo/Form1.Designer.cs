namespace _04SqlConnectionStringBiulderDemo
{
    partial class MainFrm
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
            this.btnGetString = new System.Windows.Forms.Button();
            this.textString = new System.Windows.Forms.TextBox();
            this.propGrid4connString = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btnGetString
            // 
            this.btnGetString.Location = new System.Drawing.Point(24, 12);
            this.btnGetString.Name = "btnGetString";
            this.btnGetString.Size = new System.Drawing.Size(111, 22);
            this.btnGetString.TabIndex = 0;
            this.btnGetString.Text = "获取链接字符串";
            this.btnGetString.UseVisualStyleBackColor = true;
            this.btnGetString.Click += new System.EventHandler(this.btnGetString_Click);
            // 
            // textString
            // 
            this.textString.Location = new System.Drawing.Point(24, 57);
            this.textString.Multiline = true;
            this.textString.Name = "textString";
            this.textString.Size = new System.Drawing.Size(149, 206);
            this.textString.TabIndex = 1;
            // 
            // propGrid4connString
            // 
            this.propGrid4connString.Location = new System.Drawing.Point(283, 29);
            this.propGrid4connString.Name = "propGrid4connString";
            this.propGrid4connString.Size = new System.Drawing.Size(166, 223);
            this.propGrid4connString.TabIndex = 2;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 275);
            this.Controls.Add(this.propGrid4connString);
            this.Controls.Add(this.textString);
            this.Controls.Add(this.btnGetString);
            this.Name = "MainFrm";
            this.Text = "生成链接字符串";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetString;
        private System.Windows.Forms.TextBox textString;
        private System.Windows.Forms.PropertyGrid propGrid4connString;
    }
}

