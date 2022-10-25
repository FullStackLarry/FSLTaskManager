namespace FSLTaskManager
{
    partial class UCAssignee
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PbAvatar = new System.Windows.Forms.PictureBox();
            this.LblAssigneeName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // PbAvatar
            // 
            this.PbAvatar.Location = new System.Drawing.Point(3, 3);
            this.PbAvatar.Name = "PbAvatar";
            this.PbAvatar.Size = new System.Drawing.Size(60, 60);
            this.PbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbAvatar.TabIndex = 0;
            this.PbAvatar.TabStop = false;
            // 
            // LblAssigneeName
            // 
            this.LblAssigneeName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAssigneeName.Location = new System.Drawing.Point(69, 3);
            this.LblAssigneeName.Name = "LblAssigneeName";
            this.LblAssigneeName.Size = new System.Drawing.Size(238, 60);
            this.LblAssigneeName.TabIndex = 0;
            this.LblAssigneeName.Text = "William Rumplestiltskin (Rumplestiltskin@outlook.com)";
            // 
            // UCAssignee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LblAssigneeName);
            this.Controls.Add(this.PbAvatar);
            this.Name = "UCAssignee";
            this.Size = new System.Drawing.Size(318, 66);
            this.Load += new System.EventHandler(this.UCAssignee_Load);
            this.Click += new System.EventHandler(this.UCAssignee_Click);
            ((System.ComponentModel.ISupportInitialize)(this.PbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PbAvatar;
        private Label LblAssigneeName;
    }
}
