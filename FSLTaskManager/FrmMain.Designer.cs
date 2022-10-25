namespace FSLTaskManager
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GbHeader = new System.Windows.Forms.GroupBox();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.LblUserName = new System.Windows.Forms.Label();
            this.PbAvatar = new System.Windows.Forms.PictureBox();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.GbAssignees = new System.Windows.Forms.GroupBox();
            this.FlpAssignees = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlAssignees = new System.Windows.Forms.Panel();
            this.BtnAddAssignee = new System.Windows.Forms.Button();
            this.TxtAssigneeEmail = new System.Windows.Forms.TextBox();
            this.GbTaskNotes = new System.Windows.Forms.GroupBox();
            this.FlpTaskNotes = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlTaskNotes = new System.Windows.Forms.Panel();
            this.BtnAddTaskNote = new System.Windows.Forms.Button();
            this.GbTasks = new System.Windows.Forms.GroupBox();
            this.FlpTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlTasks = new System.Windows.Forms.Panel();
            this.BtnAddTask = new System.Windows.Forms.Button();
            this.GbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbAvatar)).BeginInit();
            this.GbAssignees.SuspendLayout();
            this.PnlAssignees.SuspendLayout();
            this.GbTaskNotes.SuspendLayout();
            this.PnlTaskNotes.SuspendLayout();
            this.GbTasks.SuspendLayout();
            this.PnlTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbHeader
            // 
            this.GbHeader.Controls.Add(this.BtnSettings);
            this.GbHeader.Controls.Add(this.LblUserName);
            this.GbHeader.Controls.Add(this.PbAvatar);
            this.GbHeader.Controls.Add(this.BtnLogout);
            this.GbHeader.Controls.Add(this.BtnLogin);
            this.GbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.GbHeader.Location = new System.Drawing.Point(0, 0);
            this.GbHeader.Name = "GbHeader";
            this.GbHeader.Size = new System.Drawing.Size(1008, 100);
            this.GbHeader.TabIndex = 0;
            this.GbHeader.TabStop = false;
            // 
            // BtnSettings
            // 
            this.BtnSettings.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnSettings.Location = new System.Drawing.Point(927, 72);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(75, 23);
            this.BtnSettings.TabIndex = 3;
            this.BtnSettings.Text = "Settings";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // LblUserName
            // 
            this.LblUserName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblUserName.Location = new System.Drawing.Point(92, 12);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(829, 80);
            this.LblUserName.TabIndex = 0;
            this.LblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbAvatar
            // 
            this.PbAvatar.Location = new System.Drawing.Point(6, 12);
            this.PbAvatar.Name = "PbAvatar";
            this.PbAvatar.Size = new System.Drawing.Size(80, 80);
            this.PbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbAvatar.TabIndex = 3;
            this.PbAvatar.TabStop = false;
            // 
            // BtnLogout
            // 
            this.BtnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnLogout.Location = new System.Drawing.Point(927, 43);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(75, 23);
            this.BtnLogout.TabIndex = 2;
            this.BtnLogout.Text = "Logout";
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnLogin.Location = new System.Drawing.Point(927, 14);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 1;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // GbAssignees
            // 
            this.GbAssignees.Controls.Add(this.FlpAssignees);
            this.GbAssignees.Controls.Add(this.PnlAssignees);
            this.GbAssignees.Dock = System.Windows.Forms.DockStyle.Left;
            this.GbAssignees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GbAssignees.Location = new System.Drawing.Point(0, 100);
            this.GbAssignees.Name = "GbAssignees";
            this.GbAssignees.Size = new System.Drawing.Size(336, 629);
            this.GbAssignees.TabIndex = 1;
            this.GbAssignees.TabStop = false;
            this.GbAssignees.Text = "Assignees";
            // 
            // FlpAssignees
            // 
            this.FlpAssignees.AutoScroll = true;
            this.FlpAssignees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlpAssignees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpAssignees.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpAssignees.Location = new System.Drawing.Point(3, 57);
            this.FlpAssignees.Name = "FlpAssignees";
            this.FlpAssignees.Size = new System.Drawing.Size(330, 569);
            this.FlpAssignees.TabIndex = 1;
            this.FlpAssignees.WrapContents = false;
            // 
            // PnlAssignees
            // 
            this.PnlAssignees.Controls.Add(this.BtnAddAssignee);
            this.PnlAssignees.Controls.Add(this.TxtAssigneeEmail);
            this.PnlAssignees.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlAssignees.Location = new System.Drawing.Point(3, 19);
            this.PnlAssignees.Name = "PnlAssignees";
            this.PnlAssignees.Size = new System.Drawing.Size(330, 38);
            this.PnlAssignees.TabIndex = 0;
            // 
            // BtnAddAssignee
            // 
            this.BtnAddAssignee.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddAssignee.Location = new System.Drawing.Point(241, 8);
            this.BtnAddAssignee.Name = "BtnAddAssignee";
            this.BtnAddAssignee.Size = new System.Drawing.Size(89, 23);
            this.BtnAddAssignee.TabIndex = 1;
            this.BtnAddAssignee.Text = "Add Assignee";
            this.BtnAddAssignee.UseVisualStyleBackColor = true;
            this.BtnAddAssignee.Click += new System.EventHandler(this.BtnAddAssignee_Click);
            // 
            // TxtAssigneeEmail
            // 
            this.TxtAssigneeEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtAssigneeEmail.Location = new System.Drawing.Point(1, 8);
            this.TxtAssigneeEmail.Name = "TxtAssigneeEmail";
            this.TxtAssigneeEmail.PlaceholderText = "Enter Assignee Email";
            this.TxtAssigneeEmail.Size = new System.Drawing.Size(234, 23);
            this.TxtAssigneeEmail.TabIndex = 0;
            // 
            // GbTaskNotes
            // 
            this.GbTaskNotes.Controls.Add(this.FlpTaskNotes);
            this.GbTaskNotes.Controls.Add(this.PnlTaskNotes);
            this.GbTaskNotes.Dock = System.Windows.Forms.DockStyle.Right;
            this.GbTaskNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GbTaskNotes.Location = new System.Drawing.Point(672, 100);
            this.GbTaskNotes.Name = "GbTaskNotes";
            this.GbTaskNotes.Size = new System.Drawing.Size(336, 629);
            this.GbTaskNotes.TabIndex = 3;
            this.GbTaskNotes.TabStop = false;
            this.GbTaskNotes.Text = "Task Notes";
            // 
            // FlpTaskNotes
            // 
            this.FlpTaskNotes.AutoScroll = true;
            this.FlpTaskNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlpTaskNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpTaskNotes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpTaskNotes.Location = new System.Drawing.Point(3, 57);
            this.FlpTaskNotes.Name = "FlpTaskNotes";
            this.FlpTaskNotes.Size = new System.Drawing.Size(330, 569);
            this.FlpTaskNotes.TabIndex = 1;
            this.FlpTaskNotes.WrapContents = false;
            // 
            // PnlTaskNotes
            // 
            this.PnlTaskNotes.Controls.Add(this.BtnAddTaskNote);
            this.PnlTaskNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTaskNotes.Location = new System.Drawing.Point(3, 19);
            this.PnlTaskNotes.Name = "PnlTaskNotes";
            this.PnlTaskNotes.Size = new System.Drawing.Size(330, 38);
            this.PnlTaskNotes.TabIndex = 0;
            // 
            // BtnAddTaskNote
            // 
            this.BtnAddTaskNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddTaskNote.Location = new System.Drawing.Point(117, 7);
            this.BtnAddTaskNote.Name = "BtnAddTaskNote";
            this.BtnAddTaskNote.Size = new System.Drawing.Size(96, 23);
            this.BtnAddTaskNote.TabIndex = 0;
            this.BtnAddTaskNote.Text = "Add Task Note";
            this.BtnAddTaskNote.UseVisualStyleBackColor = true;
            this.BtnAddTaskNote.Click += new System.EventHandler(this.BtnAddTaskNote_Click);
            // 
            // GbTasks
            // 
            this.GbTasks.Controls.Add(this.FlpTasks);
            this.GbTasks.Controls.Add(this.PnlTasks);
            this.GbTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbTasks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GbTasks.Location = new System.Drawing.Point(336, 100);
            this.GbTasks.Name = "GbTasks";
            this.GbTasks.Size = new System.Drawing.Size(336, 629);
            this.GbTasks.TabIndex = 2;
            this.GbTasks.TabStop = false;
            this.GbTasks.Text = "Tasks";
            // 
            // FlpTasks
            // 
            this.FlpTasks.AutoScroll = true;
            this.FlpTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlpTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpTasks.Location = new System.Drawing.Point(3, 57);
            this.FlpTasks.Name = "FlpTasks";
            this.FlpTasks.Size = new System.Drawing.Size(330, 569);
            this.FlpTasks.TabIndex = 1;
            this.FlpTasks.WrapContents = false;
            // 
            // PnlTasks
            // 
            this.PnlTasks.Controls.Add(this.BtnAddTask);
            this.PnlTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTasks.Location = new System.Drawing.Point(3, 19);
            this.PnlTasks.Name = "PnlTasks";
            this.PnlTasks.Size = new System.Drawing.Size(330, 38);
            this.PnlTasks.TabIndex = 0;
            // 
            // BtnAddTask
            // 
            this.BtnAddTask.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddTask.Location = new System.Drawing.Point(135, 8);
            this.BtnAddTask.Name = "BtnAddTask";
            this.BtnAddTask.Size = new System.Drawing.Size(66, 23);
            this.BtnAddTask.TabIndex = 0;
            this.BtnAddTask.Text = "Add Task";
            this.BtnAddTask.UseVisualStyleBackColor = true;
            this.BtnAddTask.Click += new System.EventHandler(this.BtnAddTask_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.GbTasks);
            this.Controls.Add(this.GbTaskNotes);
            this.Controls.Add(this.GbAssignees);
            this.Controls.Add(this.GbHeader);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSL Task Manager";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.GbHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbAvatar)).EndInit();
            this.GbAssignees.ResumeLayout(false);
            this.PnlAssignees.ResumeLayout(false);
            this.PnlAssignees.PerformLayout();
            this.GbTaskNotes.ResumeLayout(false);
            this.PnlTaskNotes.ResumeLayout(false);
            this.GbTasks.ResumeLayout(false);
            this.PnlTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GbHeader;
        private Button BtnLogout;
        private Button BtnLogin;
        private Label LblUserName;
        private PictureBox PbAvatar;
        private GroupBox GbAssignees;
        private GroupBox GbTaskNotes;
        private GroupBox GbTasks;
        private Button BtnSettings;
        private FlowLayoutPanel FlpAssignees;
        private Panel PnlAssignees;
        private Button BtnAddAssignee;
        private TextBox TxtAssigneeEmail;
        private FlowLayoutPanel FlpTasks;
        private Panel PnlTasks;
        private Button BtnAddTask;
        private FlowLayoutPanel FlpTaskNotes;
        private Panel PnlTaskNotes;
        private Button BtnAddTaskNote;
    }
}