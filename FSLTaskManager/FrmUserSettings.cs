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
    public partial class FrmUserSettings : Form
    {
        public event EventHandler? DoneLoading;

        private static List<KeyValuePair<string, Image?>> images = new List<KeyValuePair<string, Image?>>();
        private APIClient _APIClient = new APIClient();

        public FrmUserSettings()
        {
            InitializeComponent();
        }

        private async void FrmUserSettings_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (images.Count == 0)
                {
                    var result = await _APIClient.GetAvatarsList();
                    if (result.Error != "")
                    {
                        MessageBox.Show(result.Error);
                    }
                    else
                    {
                        foreach (string url in result.AvatarList)
                        {
                            Image? image = await _APIClient.GetImage(url);
                            images.Add(new KeyValuePair<string, Image?>(url, image));
                        }
                    }
                }

                if (images.Count != 0)
                {
                    foreach (KeyValuePair<string, Image?> img in images)
                    {
                        AvatarImages.Images.Add(img.Key, img.Value);
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageKey = img.Key;
                        LvAvatars.Items.Add(lvi);
                    }
                }
                if (DoneLoading != null) DoneLoading.Invoke(this, EventArgs.Empty);
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

        public void SetValues(string FirstName, string LastName, string AvatarUrl)
        {
            TxtFirstName.Text = FirstName;
            TxtLastName.Text = LastName;
            foreach (ListViewItem item in LvAvatars.Items)
            {
                if (item.ImageKey == AvatarUrl) item.Selected = true;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string result = await _APIClient.SaveUserSettings(TxtFirstName.Text, TxtLastName.Text, LvAvatars.SelectedItems[0].ImageKey);
                    if (result != "")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
                ErrorProvider.SetError(TxtLastName, "First name cannot be blank");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(TxtLastName, "");
            }
        }

        private void LvAvatars_Validating(object sender, CancelEventArgs e)
        {
            if (LvAvatars.SelectedItems.Count == 0)
            {
                e.Cancel = true;
                LvAvatars.Focus();
                ErrorProvider.SetError(LvAvatars, "An avatar must be selected");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider.SetError(LvAvatars, "");
            }
        }

    }
}
