namespace _07DataImport
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
            this.btnSelectDataFile = new System.Windows.Forms.Button();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectDataFile
            // 
            this.btnSelectDataFile.Location = new System.Drawing.Point(304, 27);
            this.btnSelectDataFile.Name = "btnSelectDataFile";
            this.btnSelectDataFile.Size = new System.Drawing.Size(76, 28);
            this.btnSelectDataFile.TabIndex = 0;
            this.btnSelectDataFile.Text = "打开";
            this.btnSelectDataFile.UseVisualStyleBackColor = true;
            this.btnSelectDataFile.Click += new System.EventHandler(this.btnSelectDataFile_Click);
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(30, 32);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(246, 21);
            this.textFilePath.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 309);
            this.Controls.Add(this.textFilePath);
            this.Controls.Add(this.btnSelectDataFile);
            this.Name = "Form1";
            this.Text = "文件导入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDataFile;
        private System.Windows.Forms.TextBox textFilePath;
    }
}

