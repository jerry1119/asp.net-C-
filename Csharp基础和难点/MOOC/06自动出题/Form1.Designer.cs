namespace _06自动出题
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textAnswer = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnJudge = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "=";
            // 
            // textAnswer
            // 
            this.textAnswer.Location = new System.Drawing.Point(247, 55);
            this.textAnswer.Name = "textAnswer";
            this.textAnswer.Size = new System.Drawing.Size(100, 21);
            this.textAnswer.TabIndex = 4;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(97, 105);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(54, 24);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "出题";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnJudge
            // 
            this.btnJudge.Location = new System.Drawing.Point(229, 105);
            this.btnJudge.Name = "btnJudge";
            this.btnJudge.Size = new System.Drawing.Size(54, 24);
            this.btnJudge.TabIndex = 6;
            this.btnJudge.Text = "判分";
            this.btnJudge.UseVisualStyleBackColor = true;
            this.btnJudge.Click += new System.EventHandler(this.btnJudge_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(50, 144);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 92);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 277);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnJudge);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.textAnswer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textAnswer;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnJudge;
        private System.Windows.Forms.ListView listView1;
    }
}

