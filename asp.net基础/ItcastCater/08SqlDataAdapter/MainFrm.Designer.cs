namespace _08SqlDataAdapter
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
            this.DgvUserInfo = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvUserInfo
            // 
            this.DgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.UserName,
            this.UserPwd});
            this.DgvUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvUserInfo.Location = new System.Drawing.Point(0, 0);
            this.DgvUserInfo.Name = "DgvUserInfo";
            this.DgvUserInfo.RowTemplate.Height = 23;
            this.DgvUserInfo.Size = new System.Drawing.Size(344, 312);
            this.DgvUserInfo.TabIndex = 0;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "Id";
            this.UserId.Frozen = true;
            this.UserId.HeaderText = "编号";
            this.UserId.Name = "UserId";
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.Frozen = true;
            this.UserName.HeaderText = "姓名";
            this.UserName.Name = "UserName";
            // 
            // UserPwd
            // 
            this.UserPwd.DataPropertyName = "UserPwd";
            this.UserPwd.Frozen = true;
            this.UserPwd.HeaderText = "密码";
            this.UserPwd.Name = "UserPwd";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 312);
            this.Controls.Add(this.DgvUserInfo);
            this.Name = "MainFrm";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvUserInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPwd;
    }
}

