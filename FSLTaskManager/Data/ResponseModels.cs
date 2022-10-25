using FSLTaskManager.Models;

namespace FSLTaskManager.Data
{

     internal class ErrorResponse
    {
        public string error { get; set; } = "";
    }

     internal class TokenResponse
    {
        public string token { get; set; } = "";
    }

     internal class AvatarListResponse
    {
        public string[] avatarList { get; set; } = new string[0];
    }
}
