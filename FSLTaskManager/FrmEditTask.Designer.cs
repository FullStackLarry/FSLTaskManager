namespace FSLTaskManager
{
    partial class FrmEditTask
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
            this.LblCompletedDate = new System.Windows.Forms.Label();
            this.LblStartedDate = new System.Windows.Forms.Label();
            this.LblAssignedDate = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.CmbStatus = new System.Windows.Forms.ComboBox();
            this.DtpAssignedDate = new System.Windows.Forms.DateTimePicker();
            this.DtpCompletedDate = new System.Windows.Forms.DateTimePicker();
            this.DtpStartedDate = new System.Windows.Forms.DateTimePicker();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblAssignedBy = new System.Windows.Forms.Label();
            this.LblAssignedByValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblCompletedDate
            // 
            this.LblCompletedDate.AutoSize = true;
            this.LblCompletedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCompletedDate.Location = new System.Drawing.Point(12, 367);
            this.LblCompletedDate.Name = "LblCompletedDate";
            this.LblCompletedDate.Size = new System.Drawing.Size(71, 15);
            this.LblCompletedDate.TabIndex = 12;
            this.LblCompletedDate.Text = "Completed:";
            // 
            // LblStartedDate
            // 
            this.LblStartedDate.AutoSize = true;
            this.LblStartedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblStartedDate.Location = new System.Drawing.Point(12, 323);
            this.LblStartedDate.Name = "LblStartedDate";
            this.LblStartedDate.Size = new System.Drawing.Size(52, 15);
            this.LblStartedDate.TabIndex = 10;
            this.LblStartedDate.Text = "Started:";
            // 
            // LblAssignedDate
            // 
            this.LblAssignedDate.AutoSize = true;
            this.LblAssignedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAssignedDate.Location = new System.Drawing.Point(12, 279);
            this.LblAssignedDate.Name = "LblAssignedDate";
            this.LblAssignedDate.Size = new System.Drawing.Size(59, 15);
            this.LblAssignedDate.TabIndex = 8;
            this.LblAssignedDate.Text = "Assigned:";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblStatus.Location = new System.Drawing.Point(12, 235);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(45, 15);
            this.LblStatus.TabIndex = 6;
            this.LblStatus.Text = "Status:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblName.Location = new System.Drawing.Point(12, 51);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(43, 15);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Name:";
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblDescription.Location = new System.Drawing.Point(12, 93);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(74, 15);
            this.LblDescription.TabIndex = 4;
            this.LblDescription.Text = "Description:";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(12, 69);
            this.TxtName.MaxLength = 30;
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(242, 23);
            this.TxtName.TabIndex = 3;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(12, 111);
            this.TxtDescription.MaxLength = 200;
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(242, 121);
            this.TxtDescription.TabIndex = 5;
            // 
            // CmbStatus
            // 
            this.CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStatus.FormattingEnabled = true;
            this.CmbStatus.Items.AddRange(new object[] {
            "Not Started",
            "Started",
            "Completed"});
            this.CmbStatus.Location = new System.Drawing.Point(12, 253);
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Size = new System.Drawing.Size(242, 23);
            this.CmbStatus.TabIndex = 7;
            // 
            // DtpAssignedDate
            // 
            this.DtpAssignedDate.CustomFormat = "MM/dd/yyyy";
            this.DtpAssignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpAssignedDate.Location = new System.Drawing.Point(12, 297);
            this.DtpAssignedDate.Name = "DtpAssignedDate";
            this.DtpAssignedDate.ShowCheckBox = true;
            this.DtpAssignedDate.Size = new System.Drawing.Size(242, 23);
            this.DtpAssignedDate.TabIndex = 9;
            // 
            // DtpCompletedDate
            // 
            this.DtpCompletedDate.Checked = false;
            this.DtpCompletedDate.CustomFormat = "MM/dd/yyyy";
            this.DtpCompletedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCompletedDate.Location = new System.Drawing.Point(12, 385);
            this.DtpCompletedDate.Name = "DtpCompletedDate";
            this.DtpCompletedDate.ShowCheckBox = true;
            this.DtpCompletedDate.Size = new System.Drawing.Size(242, 23);
            this.DtpCompletedDate.TabIndex = 13;
            // 
            // DtpStartedDate
            // 
            this.DtpStartedDate.Checked = false;
            this.DtpStartedDate.CustomFormat = "MM/dd/yyyy";
            this.DtpStartedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartedDate.Location = new System.Drawing.Point(12, 341);
            this.DtpStartedDate.Name = "DtpStartedDate";
            this.DtpStartedDate.ShowCheckBox = true;
            this.DtpStartedDate.Size = new System.Drawing.Size(242, 23);
            this.DtpStartedDate.TabIndex = 11;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(136, 414);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(55, 414);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblAssignedBy
            // 
            this.LblAssignedBy.AutoSize = true;
            this.LblAssignedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAssignedBy.Location = new System.Drawing.Point(12, 9);
            this.LblAssignedBy.Name = "LblAssignedBy";
            this.LblAssignedBy.Size = new System.Drawing.Size(76, 15);
            this.LblAssignedBy.TabIndex = 0;
            this.LblAssignedBy.Text = "Assigned By:";
            // 
            // LblAssignedByValue
            // 
            this.LblAssignedByValue.AutoSize = true;
            this.LblAssignedByValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAssignedByValue.Location = new System.Drawing.Point(12, 24);
            this.LblAssignedByValue.Name = "LblAssignedByValue";
            this.LblAssignedByValue.Size = new System.Drawing.Size(0, 15);
            this.LblAssignedByValue.TabIndex = 1;
            // 
            // FrmEditTask
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(275, 449);
            this.Controls.Add(this.LblAssignedByValue);
            this.Controls.Add(this.LblAssignedBy);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.DtpStartedDate);
            this.Controls.Add(this.DtpCompletedDate);
            this.Controls.Add(this.DtpAssignedDate);
            this.Controls.Add(this.CmbStatus);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblCompletedDate);
            this.Controls.Add(this.LblStartedDate);
            this.Controls.Add(this.LblAssignedDate);
            this.Controls.Add(this.LblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblCompletedDate;
        private Label LblStartedDate;
        private Label LblAssignedDate;
        private Label LblStatus;
        private Label LblName;
        private Label LblDescription;
        private TextBox TxtName;
        private TextBox TxtDescription;
        private ComboBox CmbStatus;
        private DateTimePicker DtpAssignedDate;
        private DateTimePicker DtpCompletedDate;
        private DateTimePicker DtpStartedDate;
        private Button BtnCancel;
        private Button BtnSave;
        private Label LblAssignedBy;
        private Label LblAssignedByValue;
    }
}