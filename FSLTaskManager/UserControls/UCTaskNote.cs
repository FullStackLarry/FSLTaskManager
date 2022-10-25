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
    public partial class UCTaskNote : UserControl
    {
        public delegate void TaskEventHandler(TMTaskNote taskNote);
        public event TaskEventHandler? EditClicked;

        private TMTaskNote? _taskNote = null;

        public UCTaskNote()
        {
            InitializeComponent();
        }

        protected virtual void OnEditClicked(TMTaskNote taskNote)
        {
            EditClicked?.Invoke(taskNote);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_taskNote != null) OnEditClicked(_taskNote);
        }

        public void SetValues(TMTaskNote taskNote,
                              bool editable)
        {
            _taskNote = taskNote;
            if (_taskNote != null && _taskNote.owner != null)
            {
                LblOwnerName.Text = _taskNote.owner.fullName;
                LblEnteredDate.Text = _taskNote.enteredDate;
                LblNote.Text = _taskNote.note;
                BtnEdit.Enabled = editable;
            }
        }
    }
}
