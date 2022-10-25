using FSLTaskManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FSLTaskManager
{
    public partial class FrmLogin : Form
    {
        public delegate void TokenReceivedEventHandler(string token);
        public event TokenReceivedEventHandler? TokenReceived;

        private APIClient _APIClient = new APIClient();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    TxtEmail.Text = TxtEmail.Text.Trim();
                    TxtPassword.Text = TxtPassword.Text.Trim();
                    var result = await _APIClient.Login(TxtEmail.Text, TxtPassword.Text);
                    if (result.Token != "")
                    {
                        if (TokenReceived != null) TokenReceived(result.Token);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.Error);
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

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var f = new FrmRegister();
            f.ShowDialog();
        }

        private void BtnValidateEmail_Click(object sender, EventArgs e)
        {
            var f = new FrmValidateEmail();
            f.ShowDialog();
        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            var f = new FrmSendEmail();
            f.ShowDialog();
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

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                e.Cancel = true;
                TxtPassword.Focus();
                ErrorProvider.SetError(TxtPassword, "Password cannot be blank");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtPassword, "");
            }
        }
    }
}
