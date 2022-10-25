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
    public partial class FrmValidateEmail : Form
    {
        private APIClient _APIClient = new APIClient();

        public FrmValidateEmail()
        {
            InitializeComponent();
        }

        public void SetEmail(string email)
        {
            TxtEmail.Text = email;
        }

        private async void BtnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    TxtEmail.Text = TxtEmail.Text.Trim();
                    TxtCode.Text = TxtCode.Text.Trim();
                    var result = await _APIClient.ValidateEmail(TxtEmail.Text, TxtCode.Text);
                    if (result == "")
                    {
                        MessageBox.Show("Validation successful. You may now log in.");
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

        private void TxtCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCode.Text))
            {
                e.Cancel = true;
                TxtCode.Focus();
                ErrorProvider.SetError(TxtCode, "Validation code cannot be blank");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtCode, "");
            }
        }
    }
}
