using FSLTaskManager.Data;
using FSLTaskManager.Models;

namespace FSLTaskManager
{
    public partial class FrmEditTaskNote : Form
    {
        private readonly APIClient _apiClient = new();
        private TMTaskNote? _taskNote = null;

        public FrmEditTaskNote()
        {
            InitializeComponent();
        }

        public void SetValues(TMTaskNote taskNote)
        {
            _taskNote = taskNote;
            LblOwnerName.Text = _taskNote.owner.fullName;
            txtNote.Text = _taskNote.note;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string result = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_taskNote != null)
                {
                    _taskNote.note = txtNote.Text;
                    _taskNote.enteredDate = String.Format("{0:MM/dd/yyyy h:mm:ss tt}", DateTime.Now);

                    if (_taskNote._id == "")
                    {
                        result = _apiClient.AddTaskNote(_taskNote);
                    }
                    else
                    {
                        result = _apiClient.UpdateTaskNote(_taskNote);
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
            this.Close();
        }
    }
}
