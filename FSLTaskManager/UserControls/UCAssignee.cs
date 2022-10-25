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
    public partial class UCAssignee : UserControl
    {
        public delegate void AssigneeEventHandler(User assignee);
        public event AssigneeEventHandler? AssigneeClicked;
        private User? _assignee = null;

        public UCAssignee()
        {
            InitializeComponent();
        }

        protected virtual void OnAssigneeClicked(User assignee)
        {
            AssigneeClicked?.Invoke(assignee);
        }

        private void UCAssignee_Click(object? sender, EventArgs e)
        {
            if (_assignee != null) OnAssigneeClicked(_assignee);
        }

        public void SetValues(User user, Image? AvatarImage)
        {
            _assignee = user;
            PbAvatar.Image = AvatarImage;
            LblAssigneeName.Text = String.Format("{0} ({1})", _assignee.fullName, _assignee.email);
        }

        private void UCAssignee_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label || c is PictureBox)
                    c.Click += new EventHandler(UCAssignee_Click);
            }

        }
    }
}
