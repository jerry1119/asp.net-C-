namespace _03TreeView的使用
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textParent = new System.Windows.Forms.TextBox();
            this.textChild = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(24, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(177, 280);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加根节点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "添加子节点";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textParent
            // 
            this.textParent.Location = new System.Drawing.Point(293, 70);
            this.textParent.Name = "textParent";
            this.textParent.Size = new System.Drawing.Size(181, 21);
            this.textParent.TabIndex = 3;
            // 
            // textChild
            // 
            this.textChild.Location = new System.Drawing.Point(293, 174);
            this.textChild.Name = "textChild";
            this.textChild.Size = new System.Drawing.Size(181, 21);
            this.textChild.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 304);
            this.Controls.Add(this.textChild);
            this.Controls.Add(this.textParent);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textParent;
        private System.Windows.Forms.TextBox textChild;
    }
}

