﻿using FSLTaskManager.Data;
using System.ComponentModel;

namespace FSLTaskManager
{
    public partial class FrmSendEmail : Form
    {
        private APIClient _APIClient = new APIClient();

        public FrmSendEmail()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    TxtEmail.Text = TxtEmail.Text.Trim();
                    var result = _APIClient.SendEmail(TxtEmail.Text);
                    if (result == "")
                    {
                        MessageBox.Show("Validation email has been sent. Check your SPAM folder if you do not receive it shortly.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                e.Cancel = true;
                TxtEmail.Focus();
                ErrorProvider.SetError(TxtEmail, "Email cannot be blank");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtEmail, "");
            }
        }
    }
}
