namespace FSLTaskManager
{
    partial class FrmUserSettings
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
            this.components = new System.ComponentModel.Container();
            this.LblFirstName = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.LblLastName = new System.Windows.Forms.Label();
            this.LvAvatars = new System.Windows.Forms.ListView();
            this.AvatarImages = new System.Windows.Forms.ImageList(this.components);
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LblFirstName
            // 
            this.LblFirstName.AutoSize = true;
            this.LblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblFirstName.Location = new System.Drawing.Point(12, 9);
            this.LblFirstName.Name = "LblFirstName";
            this.LblFirstName.Size = new System.Drawing.Size(70, 15);
            this.LblFirstName.TabIndex = 0;
            this.LblFirstName.Text = "First Name:";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(88, 6);
            this.TxtFirstName.MaxLength = 30;
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.PlaceholderText = "First name";
            this.TxtFirstName.Size = new System.Drawing.Size(194, 23);
            this.TxtFirstName.TabIndex = 1;
            this.TxtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFirstName_Validating);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(399, 6);
            this.TxtLastName.MaxLength = 30;
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.PlaceholderText = "Last name";
            this.TxtLastName.Size = new System.Drawing.Size(194, 23);
            this.TxtLastName.TabIndex = 3;
            this.TxtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLastName_Validating);
            // 
            // LblLastName
            // 
            this.LblLastName.AutoSize = true;
            this.LblLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblLastName.Location = new System.Drawing.Point(323, 9);
            this.LblLastName.Name = "LblLastName";
            this.LblLastName.Size = new System.Drawing.Size(68, 15);
            this.LblLastName.TabIndex = 2;
            this.LblLastName.Text = "Last Name:";
            // 
            // LvAvatars
            // 
            this.LvAvatars.LargeImageList = this.AvatarImages;
            this.LvAvatars.Location = new System.Drawing.Point(12, 35);
            this.LvAvatars.MultiSelect = false;
            this.LvAvatars.Name = "LvAvatars";
            this.LvAvatars.Size = new System.Drawing.Size(581, 359);
            this.LvAvatars.TabIndex = 4;
            this.LvAvatars.UseCompatibleStateImageBehavior = false;
            this.LvAvatars.Validating += new System.ComponentModel.CancelEventHandler(this.LvAvatars_Validating);
            // 
            // AvatarImages
            // 
            this.AvatarImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.AvatarImages.ImageSize = new System.Drawing.Size(50, 50);
            this.AvatarImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(226, 410);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(307, 410);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // FrmUserSettings
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(608, 443);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LvAvatars);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.LblLastName);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.LblFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Settings";
            this.Load += new System.EventHandler(this.FrmUserSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblFirstName;
        private TextBox TxtFirstName;
        private TextBox TxtLastName;
        private Label LblLastName;
        private ListView LvAvatars;
        private Button BtnSave;
        private Button BtnCancel;
        private ImageList AvatarImages;
        private ErrorProvider ErrorProvider;
    }
}