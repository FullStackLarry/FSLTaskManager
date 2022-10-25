using FSLTaskManager.Models;

namespace FSLTaskManager.Data
{
    internal class LoginResult
    {
        public string Token = "";
        public string Error = "";
    }

     internal class RegistrationResult
    {
        public bool Success = false;
        public bool EmailFailed = false;
        public string Error = "";
    }

     internal class UserResult
    {
        public User UserInfo = new User();
        public string Error = "";
    }

     internal class AvatarListResult
    {
        public string[] AvatarList = new string[0];
        public string Error = "";
    }

    internal class UserAssigneesResult
    {
        public User[] Assignees = new User[0];
        public string Error = "";
    }

    internal class TasksResult
    {
        public TMTask[] Tasks = new TMTask[0];
        public string Error = "";
    }

    internal class TaskNotesResult
    {
        public TMTaskNote[] TaskNotes = new TMTaskNote[0];
        public string Error = "";
    }
}
