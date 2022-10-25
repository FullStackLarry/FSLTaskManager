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

namespace FSLTaskManager
{
    public partial class FrmRegister : Form
    {
        private APIClient _APIClient = new APIClient();

        public FrmRegister()
        {
            InitializeComponent();
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    TxtEmail.Text = TxtEmail.Text.Trim();
                    TxtFirstName.Text = TxtFirstName.Text.Trim();
                    TxtLastName.Text = TxtLastName.Text.Trim();
                    var result = await _APIClient.Register(TxtEmail.Text, TxtFirstName.Text, TxtLastName.Text, TxtPassword.Text);
                    if (result.Success)
                    {
                        MessageBox.Show(String.Format("Your account has been created. A verification code has been sent to {0}.", TxtEmail.Text));
                        this.Hide();
                        var f = new FrmValidateEmail();
                        f.SetEmail(TxtEmail.Text);
                        f.ShowDialog();
                        this.Close();
                    }
                    else if (result.EmailFailed)
                    {
                        MessageBox.Show(String.Format("Your account has been created, but sending the verification email failed. Click Send Email on Login screen to try again.", TxtEmail.Text));
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

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordMatch();
        }

        private void TxtConfirm_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordMatch();
        }

        private void CheckPasswordMatch()
        {
            if (TxtPassword.Text != TxtConfirm.Text)
                ErrorProvider.SetError(TxtConfirm, "Passwords Do Not Match");
            else
                ErrorProvider.SetError(TxtConfirm, "");
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

        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text))
            {
                e.Cancel = true;
                TxtFirstName.Focus();
                ErrorProvider.SetError(TxtFirstName, "First name cannot be blank");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtFirstName, "");
            }
        }

        private void TxtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                e.Cancel = true;
                TxtLastName.Focus();
                ErrorProvider.SetError(TxtLastName, "Last name cannot be blank");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtLastName, "");
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

        private void TxtConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (TxtConfirm.Text != TxtPassword.Text)
            {
                e.Cancel = true;
                TxtConfirm.Focus();
                ErrorProvider.SetError(TxtConfirm, "Passwords must match");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtConfirm, "");
            }
        }
    }
}
