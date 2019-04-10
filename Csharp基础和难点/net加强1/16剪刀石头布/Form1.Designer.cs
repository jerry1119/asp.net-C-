namespace _16剪刀石头布
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
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "玩家出拳：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(211, 59);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(41, 12);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "label2";
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(482, 59);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(41, 12);
            this.lblCpu.TabIndex = 2;
            this.lblCpu.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "电脑出拳：";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(356, 166);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 12);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "结果：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(442, 238);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 24);
            this.button3.TabIndex = 6;
            this.button3.Text = "布";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "石头";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.石头_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "剪刀";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 345);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

