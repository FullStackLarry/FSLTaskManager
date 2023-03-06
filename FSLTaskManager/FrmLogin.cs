using FSLTaskManager.Data;
using System.ComponentModel;

namespace FSLTaskManager
{
    public partial class FrmLogin : Form
    {
        public delegate void TokenReceivedEventHandler(string token);
        public event TokenReceivedEventHandler? TokenReceived;

        private readonly APIClient _APIClient = new();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    TxtEmail.Text = TxtEmail.Text.Trim();
                    TxtPassword.Text = TxtPassword.Text.Trim();
                    var result = _APIClient.Login(TxtEmail.Text, TxtPassword.Text);
                    if (result.Token != "")
                    {
                        TokenReceived?.Invoke(result.Token);
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
