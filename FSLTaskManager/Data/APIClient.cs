using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Collections;
using FSLTaskManager.Models;

namespace FSLTaskManager.Data
{
    internal class APIClient
    {
#if DEBUG
        private const string BASE_URL = "http://127.0.0.1:5000/";
#else
        private const string BASE_URL = "https://fslapi.herokuapp.com/";
#endif
        private const string API_URL = BASE_URL  + "v1/";

        private HttpClient _http;

        public APIClient()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(API_URL);
        }

        public static string userToken = "";

        private void SetUserToken()
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

        }

        private void RemoveUserToken()
        {
            _http.DefaultRequestHeaders.Authorization = null;
        }

        private static Hashtable cachedImages = new Hashtable();

        public async Task<Image?> GetImage(string url)
        {
            try
            {
                if (cachedImages.ContainsKey(url))
                {
                    return (Image?)cachedImages[url];
                }
                string imageUrl = BASE_URL + url;
                var imageBytes = await _http.GetByteArrayAsync(imageUrl);
                Image image = Image.FromStream(new MemoryStream(imageBytes));
                cachedImages.Add(url, image);
                return image;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LoginResult> Login(string Email, string Password)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("password", Password)
            });

            HttpResponseMessage resp = await _http.PostAsync("auth/login", content);

            LoginResult loginResult = new LoginResult();

            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TokenResponse? tokenResponse = await resp.Content.ReadFromJsonAsync<TokenResponse>();
                if (tokenResponse != null ) loginResult.Token = tokenResponse.token;
                return loginResult;
            }
            ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
            if (errorResponse != null) loginResult.Error = errorResponse.error;
            return loginResult;
        }

        public async Task<RegistrationResult> Register(string Email, string FirstName, string LastName, string Password)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("firstName", FirstName),
                new KeyValuePair<string,string>("lastName", LastName),
                new KeyValuePair<string,string>("password", Password)
            });

            HttpResponseMessage resp = await _http.PostAsync("auth/register", content);

            RegistrationResult registrationResult = new RegistrationResult();

            if (resp.StatusCode == System.Net.HttpStatusCode.Created)
            {
                registrationResult.Success = true;
                return registrationResult;
            }
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                registrationResult.EmailFailed = true;
                return registrationResult;
            }
            ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
            if (errorResponse != null) registrationResult.Error = errorResponse.error;
            return registrationResult;
        }

        public async Task<String> ValidateEmail(string Email, string Code)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("code", Code)
            });

            HttpResponseMessage resp = await _http.PostAsync("auth/validateemail", content);

            if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return "";
            ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
            if (errorResponse != null) return errorResponse.error;
            else return "";
        }

        public async Task<String> SendEmail(string Email)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email)
            });

            HttpResponseMessage resp = await _http.PostAsync("auth/sendemail", content);

            if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return "";
            ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
            if (errorResponse != null) return errorResponse.error;
            else return "";
        }

        public async Task<UserResult> GetLoggedInUser()
        {
            try
            {
                SetUserToken();
                HttpResponseMessage resp = await _http.GetAsync("users");

                UserResult userResult = new UserResult();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    User? userResponse = await resp.Content.ReadFromJsonAsync<User>();
                    if (userResponse != null)
                    {
                        userResult.UserInfo = userResponse;
                    }
                    return userResult;
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) userResult.Error = errorResponse.error;
                return userResult;
            }
            catch (Exception)
            {
                return new UserResult { Error = "Invalid User" };
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<UserResult> GetUser(string UserId)
        {
            try
            {
                SetUserToken();
                HttpResponseMessage resp = await _http.GetAsync("users/" + UserId);

                UserResult userResult = new UserResult();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    User? userResponse = await resp.Content.ReadFromJsonAsync<User>();
                    if (userResponse != null)
                    {
                        userResult.UserInfo = userResponse;
                    }
                    return userResult;
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) userResult.Error = errorResponse.error;
                return userResult;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<AvatarListResult> GetAvatarsList()
        {
            try
            {
                SetUserToken();
                HttpResponseMessage resp = await _http.GetAsync("users/avatars/list");

                AvatarListResult avatarListResult = new AvatarListResult();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    AvatarListResponse? avatarListResponse = await resp.Content.ReadFromJsonAsync<AvatarListResponse>();
                    if (avatarListResponse != null) avatarListResult.AvatarList = avatarListResponse.avatarList;
                    return avatarListResult;
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) avatarListResult.Error = errorResponse.error;
                return avatarListResult;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<string> SaveUserSettings(string FirstName, string LastName, string AvatarUrl)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("firstName", FirstName),
                    new KeyValuePair<string,string>("lastName", LastName),
                    new KeyValuePair<string,string>("avatarUrl", AvatarUrl)
                });

                HttpResponseMessage resp = await _http.PutAsync("users/", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) return errorResponse.error;
                else return "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<UserAssigneesResult> GetUserAssignees()
        {
            try
            {
                SetUserToken();
                HttpResponseMessage resp = await _http.GetAsync("TM/assignees");

                UserAssigneesResult assigneesResult = new UserAssigneesResult();

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return assigneesResult;
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    User[]? assigneesResponse = await resp.Content.ReadFromJsonAsync<User[]?>();
                    if (assigneesResponse != null) assigneesResult.Assignees = assigneesResponse;
                    return assigneesResult;
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) assigneesResult.Error = errorResponse.error;
                return assigneesResult;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<string> AddAssignee(string Email)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("email", Email),
                });

                HttpResponseMessage resp = await _http.PostAsync("TM/assignees", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "";
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) return errorResponse.error;
                else return "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<TasksResult> GetTasks(string AssigneeId)
        {
            try
            {
                SetUserToken();
                HttpResponseMessage resp = await _http.GetAsync("TM/tasks/" + AssigneeId);

                TasksResult taskResult = new TasksResult();

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return taskResult;
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TMTask[]? tasksResponse = await resp.Content.ReadFromJsonAsync<TMTask[]>();
                    if (tasksResponse != null)
                    {
                        taskResult.Tasks = tasksResponse;
                        foreach (TMTask task in taskResult.Tasks)
                        {
                            var result = await GetUser(task.owner);
                            if (result.Error == "")
                            {
                                task.ownerName = result.UserInfo.fullName;
                            }
                        }
                    }
                    return taskResult;
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) taskResult.Error = errorResponse.error;
                return taskResult;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<string> AddTask(TMTask task)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("assignedTo", task.assignedTo),
                    new KeyValuePair<string,string>("name", task.name),
                    new KeyValuePair<string,string>("description", task.description),
                    new KeyValuePair<string,string>("status", task.status),
                    new KeyValuePair<string,string>("assignedDate", task.assignedDate),
                    new KeyValuePair<string,string>("startedDate", task.startedDate),
                    new KeyValuePair<string,string>("completedDate", task.completedDate)
                });

                HttpResponseMessage resp = await _http.PostAsync("TM/tasks", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "";
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) return errorResponse.error;
                else return "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<string> UpdateTask(TMTask task)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("_id", task._id),
                    new KeyValuePair<string,string>("assignedTo", task.assignedTo),
                    new KeyValuePair<string,string>("name", task.name),
                    new KeyValuePair<string,string>("description", task.description),
                    new KeyValuePair<string,string>("status", task.status),
                    new KeyValuePair<string,string>("assignedDate", task.assignedDate),
                    new KeyValuePair<string,string>("startedDate", task.startedDate),
                    new KeyValuePair<string,string>("completedDate", task.completedDate)
                });

                HttpResponseMessage resp = await _http.PutAsync("TM/tasks", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) return errorResponse.error;
                else return "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<TaskNotesResult> GetTaskNotes(string TaskId)
        {
            try
            {
                SetUserToken();
                HttpResponseMessage resp = await _http.GetAsync("TM/tasknotes/" + TaskId);

                TaskNotesResult taskNotesResult = new TaskNotesResult();

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return taskNotesResult;
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //var value = await resp.Content.ReadAsStringAsync();
                    TMTaskNote[]? taskNotesResponse = await resp.Content.ReadFromJsonAsync<TMTaskNote[]>();
                    if (taskNotesResponse != null)
                    {
                        taskNotesResult.TaskNotes = taskNotesResponse;
                    }
                    return taskNotesResult;
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) taskNotesResult.Error = errorResponse.error;
                return taskNotesResult;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<string> AddTaskNote(TMTaskNote taskNote)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("task", taskNote.task),
                    new KeyValuePair<string,string>("enteredDate", taskNote.enteredDate),
                    new KeyValuePair<string,string>("note", taskNote.note),
                });

                HttpResponseMessage resp = await _http.PostAsync("TM/tasknotes", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "";
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) return errorResponse.error;
                else return "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }

        public async Task<string> UpdateTaskNote(TMTaskNote taskNote)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("_id", taskNote._id),
                    new KeyValuePair<string,string>("enteredDate", taskNote.enteredDate),
                    new KeyValuePair<string,string>("note", taskNote.note),
                });

                HttpResponseMessage resp = await _http.PutAsync("TM/tasknotes", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                ErrorResponse? errorResponse = await resp.Content.ReadFromJsonAsync<ErrorResponse>();
                if (errorResponse != null) return errorResponse.error;
                else return "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                RemoveUserToken();
            }
        }
    }
}
