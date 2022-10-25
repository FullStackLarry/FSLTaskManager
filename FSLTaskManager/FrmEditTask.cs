using FSLTaskManager.Data;
using FSLTaskManager.Models;
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
    public partial class FrmEditTask : Form
    {
        private APIClient _apiClient = new APIClient();
        private TMTask? _task = null;

        public FrmEditTask()
        {
            InitializeComponent();
        }

        public void SetValues(TMTask task)
        {
            _task = task;
            LblAssignedByValue.Text = task.ownerName;
            TxtName.Text = task.name;
            TxtDescription.Text = task.description;
            CmbStatus.SelectedIndex = 0;
            for (int i = 0; i < CmbStatus.Items.Count; i++)
            {
                if ((string)CmbStatus.Items[i] == task.status)
                {
                    CmbStatus.SelectedIndex = i;
                    break;
                }
            }
            // TODO: change DateTimePicker control to a control that is nullable
            if (task.assignedDate != "")
            {
                DtpAssignedDate.Checked = true;
                DtpAssignedDate.Value = Convert.ToDateTime(task.assignedDate);
            }
            else
                DtpAssignedDate.Checked = false;

            if (task.startedDate != "")
            {
                DtpStartedDate.Checked = true;
                DtpStartedDate.Value = Convert.ToDateTime(task.startedDate);
            }
            else
                DtpStartedDate.Checked = false;


            if (task.completedDate != "")
            {
                DtpCompletedDate.Checked = true;
                DtpCompletedDate.Value = Convert.ToDateTime(task.completedDate);
            }
            else
                DtpCompletedDate.Checked= false;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string result = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_task != null)
                {
                    _task.name = TxtName.Text;
                    _task.description = TxtDescription.Text;
                    _task.status = CmbStatus.Text;
                    _task.assignedDate = DtpAssignedDate.Checked ? DtpAssignedDate.Text : "";
                    _task.startedDate = DtpStartedDate.Checked ? DtpStartedDate.Text : "";
                    _task.completedDate = DtpCompletedDate.Checked ? DtpCompletedDate.Text : "";

                    if (_task._id == "")
                    {
                        result = await _apiClient.AddTask(_task);
                    }
                    else
                    {
                        result = await _apiClient.UpdateTask(_task);
                    }
                }

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
    }
}
