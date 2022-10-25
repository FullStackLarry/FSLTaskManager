namespace FSLTaskManager
{
    partial class FrmLogin
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
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnRegister = new System.Windows.Forms.Button();
            this.LblRegister = new System.Windows.Forms.Label();
            this.LblValidateEmail = new System.Windows.Forms.Label();
            this.BtnValidateEmail = new System.Windows.Forms.Button();
            this.LblSendEmail = new System.Windows.Forms.Label();
            this.BtnSendEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblEmail.Location = new System.Drawing.Point(12, 9);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(36, 15);
            this.LblEmail.TabIndex = 0;
            this.LblEmail.Text = "Email";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(77, 6);
            this.TxtEmail.MaxLength = 256;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.PlaceholderText = "Enter email";
            this.TxtEmail.Size = new System.Drawing.Size(370, 23);
            this.TxtEmail.TabIndex = 1;
            this.TxtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmail_Validating);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(77, 40);
            this.TxtPassword.MaxLength = 20;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.PlaceholderText = "Enter password";
            this.TxtPassword.Size = new System.Drawing.Size(370, 23);
            this.TxtPassword.TabIndex = 3;
            this.TxtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPassword_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(157, 69);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(238, 69);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // BtnRegister
            // 
            this.BtnRegister.Location = new System.Drawing.Point(88, 100);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(95, 23);
            this.BtnRegister.TabIndex = 6;
            this.BtnRegister.Text = "Register";
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // LblRegister
            // 
            this.LblRegister.AutoSize = true;
            this.LblRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRegister.Location = new System.Drawing.Point(196, 104);
            this.LblRegister.Name = "LblRegister";
            this.LblRegister.Size = new System.Drawing.Size(186, 15);
            this.LblRegister.TabIndex = 7;
            this.LblRegister.Text = "Click  if you have not registered.";
            // 
            // LblValidateEmail
            // 
            this.LblValidateEmail.AutoSize = true;
            this.LblValidateEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblValidateEmail.Location = new System.Drawing.Point(196, 133);
            this.LblValidateEmail.Name = "LblValidateEmail";
            this.LblValidateEmail.Size = new System.Drawing.Size(162, 15);
            this.LblValidateEmail.TabIndex = 9;
            this.LblValidateEmail.Text = "Click  to validate your email.";
            // 
            // BtnValidateEmail
            // 
            this.BtnValidateEmail.Location = new System.Drawing.Point(88, 129);
            this.BtnValidateEmail.Name = "BtnValidateEmail";
            this.BtnValidateEmail.Size = new System.Drawing.Size(95, 23);
            this.BtnValidateEmail.TabIndex = 8;
            this.BtnValidateEmail.Text = "Validate Email";
            this.BtnValidateEmail.UseVisualStyleBackColor = true;
            this.BtnValidateEmail.Click += new System.EventHandler(this.BtnValidateEmail_Click);
            // 
            // LblSendEmail
            // 
            this.LblSendEmail.AutoSize = true;
            this.LblSendEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblSendEmail.Location = new System.Drawing.Point(196, 162);
            this.LblSendEmail.Name = "LblSendEmail";
            this.LblSendEmail.Size = new System.Drawing.Size(173, 15);
            this.LblSendEmail.TabIndex = 11;
            this.LblSendEmail.Text = "Click  to send validation email.";
            // 
            // BtnSendEmail
            // 
            this.BtnSendEmail.Location = new System.Drawing.Point(88, 158);
            this.BtnSendEmail.Name = "BtnSendEmail";
            this.BtnSendEmail.Size = new System.Drawing.Size(95, 23);
            this.BtnSendEmail.TabIndex = 10;
            this.BtnSendEmail.Text = "Send Email";
            this.BtnSendEmail.UseVisualStyleBackColor = true;
            this.BtnSendEmail.Click += new System.EventHandler(this.BtnSendEmail_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(471, 189);
            this.Controls.Add(this.LblSendEmail);
            this.Controls.Add(this.BtnSendEmail);
            this.Controls.Add(this.LblValidateEmail);
            this.Controls.Add(this.BtnValidateEmail);
            this.Controls.Add(this.LblRegister);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.LblEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblEmail;
        private TextBox TxtEmail;
        private TextBox TxtPassword;
        private Label label1;
        private Button BtnLogin;
        private Button BtnCancel;
        private ErrorProvider ErrorProvider;
        private Label LblSendEmail;
        private Button BtnSendEmail;
        private Label LblValidateEmail;
        private Button BtnValidateEmail;
        private Label LblRegister;
        private Button BtnRegister;
    }
}