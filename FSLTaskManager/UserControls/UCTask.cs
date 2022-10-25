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
    public partial class UCTask : UserControl
    {
        public delegate void TaskEventHandler(TMTask task);
        public event TaskEventHandler? TaskClicked;
        public event TaskEventHandler? EditClicked;
        private TMTask _task = new TMTask();

        public UCTask()
        {
            InitializeComponent();
        }

        protected virtual void OnTaskClicked(TMTask task)
        {
            TaskClicked?.Invoke(task);
        }

        protected virtual void OnEditClicked(TMTask task)
        {
            EditClicked?.Invoke(task);
        }

        private void UCTask_Click(object? sender, EventArgs e)
        {
            OnTaskClicked(_task);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked(_task);
        }

        public void SetValues(TMTask task,
                              bool Editable)
        {
            _task = task;
            LblName.Text = _task.name;
            LblDescription.Text = task.description;
            LblStatusValue.Text = task.status;
            LblAssignedByValue.Text = task.ownerName;
            LblAssignedDateValue.Text = task.assignedDate;
            LblStartedDateValue.Text = task.startedDate;
            LblCompletedDateValue.Text = task.completedDate;
            BtnEdit.Enabled = Editable;
        }

        private void UCTask_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                    c.Click += new EventHandler(UCTask_Click);
            }
        }
    }
}
