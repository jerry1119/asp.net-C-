namespace SqlCommandBuiderCRUD
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
            this.dgvUserInfoCRUD = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfoCRUD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserInfoCRUD
            // 
            this.dgvUserInfoCRUD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfoCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserInfoCRUD.Location = new System.Drawing.Point(0, 0);
            this.dgvUserInfoCRUD.Name = "dgvUserInfoCRUD";
            this.dgvUserInfoCRUD.RowTemplate.Height = 23;
            this.dgvUserInfoCRUD.Size = new System.Drawing.Size(384, 312);
            this.dgvUserInfoCRUD.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvUserInfoCRUD);
            this.Name = "MainFrm";
            this.Text = "CRUD";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfoCRUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserInfoCRUD;
        private System.Windows.Forms.Button btnSave;
    }
}

