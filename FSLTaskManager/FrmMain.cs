using FSLTaskManager.Data;
using FSLTaskManager.Models;

namespace FSLTaskManager
{
    public partial class FrmMain : Form
    {
        private const string TOKEN_REGISTRY_KEY = "HKEY_CURRENT_USER\\Software\\FSLTaskManager";
        private const string TOKEN_REGISTRY_NAME = "token";

        private APIClient _APIClient = new APIClient();

        private User? _currentUser = null;
        private User? _currentAssignee = null;
        private TMTask? _currentTask = null;
        
        private FrmUserSettings? _userSettings;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            object? token = Microsoft.Win32.Registry.GetValue(TOKEN_REGISTRY_KEY, TOKEN_REGISTRY_NAME, "");
            if (token == null) token = "";
            LoadUser((string)token);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            LoadAssignees();

            LoadTasks();

            LoadTaskNotes();
        }

        private async void LoadUser(string token)
        {
            Microsoft.Win32.Registry.SetValue(TOKEN_REGISTRY_KEY, TOKEN_REGISTRY_NAME, token);

            APIClient.userToken = token;

            _currentUser = null;
            _currentAssignee = null;
            _currentTask = null;

            BtnLogin.Enabled = true;
            BtnLogout.Enabled = false;
            BtnSettings.Enabled = false;
            PbAvatar.Image = null;
            LblUserName.Text = "";

            if (token != "")
            {
                APIClient apiClient = new APIClient();
                var result = await apiClient.GetLoggedInUser();
                if (result.Error != "")
                {
                    MessageBox.Show(result.Error);
                }
                else
                {
                    _currentUser = result.UserInfo;

                    BtnLogin.Enabled = false;
                    BtnLogout.Enabled = true;
                    BtnSettings.Enabled = true;
                    LblUserName.Text = _currentUser.fullName;
                    PbAvatar.Image = await apiClient.GetImage(_currentUser.avatarUrl);
                }
            }

            LoadAssignees();
        }

        private async void LoadAssignees()
        {
            FlpAssignees.Controls.Clear();

            if (_currentUser == null)
            {
                GbAssignees.Visible = false;
                GbTasks.Visible = false;
                GbTaskNotes.Visible = false;
            }
            else
            {
                GbAssignees.Visible = true;
                GbTasks.Visible = true;
                GbTaskNotes.Visible = true;

                var assignee = new UCAssignee();
                assignee.AssigneeClicked += AssigneeClicked;
                assignee.SetValues(_currentUser, PbAvatar.Image);
                FlpAssignees.Controls.Add(assignee);
                _currentAssignee = _currentUser;

                var userAssignees = await _APIClient.GetUserAssignees();
                if (userAssignees.Error == "")
                {
                    GbAssignees.Visible = true;
                    
                    if (userAssignees.Assignees.Length > 0)
                    {
                        foreach (User user in userAssignees.Assignees)
                        {
                            assignee = new UCAssignee();
                            assignee.AssigneeClicked += AssigneeClicked;
                            Image? image = await _APIClient.GetImage(user.avatarUrl);
                            assignee.SetValues(user, image);
                            FlpAssignees.Controls.Add(assignee);

                        }
                        LoadTasks();
                    }
                }
                else
                {
                    MessageBox.Show(userAssignees.Error);
                }
            }
            LoadTasks();
        }

        private async void LoadTasks()
        {
            FlpTasks.Controls.Clear();

            if (_currentAssignee == null)
            {
                BtnAddTask.Enabled = false;
                _currentTask = null;
            }
            else
            {
                BtnAddTask.Enabled = true;
                var userTasks = await _APIClient.GetTasks(_currentAssignee._id);
                if (userTasks.Error == "")
                {

                    if (_currentUser != null && userTasks.Tasks.Length > 0)
                    {
                        _currentTask = userTasks.Tasks[0];
                        foreach (TMTask userTask in userTasks.Tasks)
                        {
                            var task = new UCTask();
                            task.TaskClicked += TaskClicked;
                            task.EditClicked += TaskEditClicked;
                            task.SetValues(userTask,
                                           (_currentUser._id == userTask.owner));
                            FlpTasks.Controls.Add(task);
                        }
                    }
                    else
                    {
                        _currentTask = null;
                    }
                }
                else
                {
                    MessageBox.Show(userTasks.Error);
                }
            }
            LoadTaskNotes();
        }

        private async void LoadTaskNotes()
        {
            FlpTaskNotes.Controls.Clear();

            if (_currentTask == null)
            {
                BtnAddTaskNote.Enabled = false;
            }
            else
            {
                BtnAddTaskNote.Enabled = true;
                var taskNotes = await _APIClient.GetTaskNotes(_currentTask._id);
                if (taskNotes.Error == "")
                {

                    if (_currentUser != null && taskNotes.TaskNotes.Length > 0)
                    {
                        foreach (TMTaskNote taskNote in taskNotes.TaskNotes)
                        {
                            var note = new UCTaskNote();
                            note.EditClicked += TaskNoteEditClicked;
                            note.SetValues(taskNote,
                                           (_currentUser._id == taskNote.owner._id));
                            FlpTaskNotes.Controls.Add(note);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(taskNotes.Error);
                }
            }

        }

        private void AssigneeClicked(User assignee)
        {
            _currentAssignee = assignee;
            LoadTasks();
        }

        private void TaskClicked(TMTask task)
        {
            _currentTask = task;
            LoadTaskNotes();
        }

        private void TaskEditClicked(TMTask task)
        {
            FrmEditTask f = new FrmEditTask();
            f.SetValues(task);
            if (f.ShowDialog() == DialogResult.OK) LoadTasks();
        }

        private void TaskNoteEditClicked(TMTaskNote taskNote)
        {
            FrmEditTaskNote f = new FrmEditTaskNote();
            f.SetValues(taskNote);
            if (f.ShowDialog() == DialogResult.OK) LoadTaskNotes();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var f = new FrmLogin();
            f.TokenReceived += LoadUser;
            f.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LoadUser("");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            _userSettings = new FrmUserSettings();
            _userSettings.DoneLoading += SettingsFormLoaded;

            if (_userSettings.ShowDialog() == DialogResult.OK)
            {
                LoadUser(APIClient.userToken);
            }
        }

        private void SettingsFormLoaded(object? sender, EventArgs e)
        {
            if (_currentUser != null && _userSettings != null)
                _userSettings.SetValues(_currentUser.firstName, _currentUser.lastName, _currentUser.avatarUrl);
        }

        private async void BtnAddAssignee_Click(object sender, EventArgs e)
        {
            TxtAssigneeEmail.Text = TxtAssigneeEmail.Text.Trim();
            if (TxtAssigneeEmail.Text == "")
            {
                MessageBox.Show("Assignee email cannot be blank");
                TxtAssigneeEmail.Focus();
                return;
            }

            var result = await _APIClient.AddAssignee(TxtAssigneeEmail.Text);
            if (result == "")
            {
                LoadAssignees();
                return;
            }
            MessageBox.Show(result);
        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            if (_currentUser != null && _currentAssignee != null)
            {
                FrmEditTask f = new FrmEditTask();
                TMTask newTask = new TMTask();
                newTask.owner = _currentUser._id;
                newTask.ownerName = _currentUser.fullName;
                newTask.assignedTo = _currentAssignee._id;
                f.SetValues(newTask);
                if (f.ShowDialog() == DialogResult.OK) LoadTasks();
            }

        }

        private void BtnAddTaskNote_Click(object sender, EventArgs e)
        {
            if (_currentUser != null && _currentTask != null)
            {
                FrmEditTaskNote f = new FrmEditTaskNote();
                TMTaskNote newTaskNote = new TMTaskNote();
                newTaskNote.task = _currentTask._id;
                newTaskNote.owner = _currentUser;
                f.SetValues(newTaskNote);
                if (f.ShowDialog() == DialogResult.OK) LoadTaskNotes();
            }
        }
    }
}