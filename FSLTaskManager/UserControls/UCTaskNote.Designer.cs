namespace FSLTaskManager
{
    partial class UCTaskNote
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
            this.BtnEdit = new System.Windows.Forms.Button();
            this.LblOwnerName = new System.Windows.Forms.Label();
            this.LblEnteredDate = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.BtnEdit.Location = new System.Drawing.Point(113, 176);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 3;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // LblOwnerName
            // 
            this.LblOwnerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblOwnerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblOwnerName.Location = new System.Drawing.Point(0, 0);
            this.LblOwnerName.Name = "LblOwnerName";
            this.LblOwnerName.Size = new System.Drawing.Size(300, 24);
            this.LblOwnerName.TabIndex = 0;
            this.LblOwnerName.Text = "Owner Name";
            this.LblOwnerName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblEnteredDate
            // 
            this.LblEnteredDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblEnteredDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblEnteredDate.Location = new System.Drawing.Point(0, 24);
            this.LblEnteredDate.Name = "LblEnteredDate";
            this.LblEnteredDate.Size = new System.Drawing.Size(300, 24);
            this.LblEnteredDate.TabIndex = 1;
            this.LblEnteredDate.Text = "10/24/2022 9:02:11 PM";
            this.LblEnteredDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblNote
            // 
            this.LblNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNote.Location = new System.Drawing.Point(0, 48);
            this.LblNote.Name = "LblNote";
            this.LblNote.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LblNote.Size = new System.Drawing.Size(300, 125);
            this.LblNote.TabIndex = 2;
            this.LblNote.Text = "This is the note";
            // 
            // UCTaskNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.LblEnteredDate);
            this.Controls.Add(this.LblOwnerName);
            this.Controls.Add(this.BtnEdit);
            this.Name = "UCTaskNote";
            this.Size = new System.Drawing.Size(300, 202);
            this.ResumeLayout(false);

        }

        #endregion
        private Button BtnEdit;
        private Label LblOwnerName;
        private Label LblEnteredDate;
        private Label LblNote;
    }
}
