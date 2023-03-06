using FSLTaskManager.Models;
using System.Collections;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FSLTaskManager.Data
{
    internal class APIClient
    {
#if DEBUG
        private const string BASE_URL = "http://127.0.0.1:5000/";
#else
        private const string BASE_URL = "https://fslapi.herokuapp.com/";
#endif
        private const string API_URL = BASE_URL + "v1/";

        private readonly HttpClient _http;

        public APIClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(API_URL)
            };
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

        private static readonly Hashtable cachedImages = new();

        public Image? GetImage(string url)
        {
            try
            {
                if (cachedImages.ContainsKey(url))
                {
                    return (Image?)cachedImages[url];
                }
                string imageUrl = BASE_URL + url;
                var task = Task.Run(() => _http.GetByteArrayAsync(imageUrl));
                task.Wait();
                var imageBytes = task.Result;
                Image image = Image.FromStream(new MemoryStream(imageBytes));
                cachedImages.Add(url, image);
                return image;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LoginResult Login(string Email, string Password)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("password", Password)
            });

            var taskPost = Task.Run(() => _http.PostAsync("auth/login", content));
            taskPost.Wait();
            HttpResponseMessage resp = taskPost.Result;

            LoginResult loginResult = new();

            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var taskReadOK = Task.Run(() => resp.Content.ReadFromJsonAsync<TokenResponse>());
                taskReadOK.Wait();
                TokenResponse? tokenResponse = taskReadOK.Result;
                if (tokenResponse != null) loginResult.Token = tokenResponse.token;
                return loginResult;
            }
            var taskReadError = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
            taskReadError.Wait();
            ErrorResponse? errorResponse = taskReadError.Result;
            if (errorResponse != null) loginResult.Error = errorResponse.error;
            return loginResult;
        }

        public RegistrationResult Register(string Email, string FirstName, string LastName, string Password)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("firstName", FirstName),
                new KeyValuePair<string,string>("lastName", LastName),
                new KeyValuePair<string,string>("password", Password)
            });

            //HttpResponseMessage resp = _http.PostAsync("auth/register", content);
            var t1 = Task.Run(() => _http.PostAsync("auth/register", content));
            t1.Wait();
            HttpResponseMessage resp = t1.Result;

            RegistrationResult registrationResult = new();

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
            //ErrorResponse? errorResponse = resp.Content.ReadFromJsonAsync<ErrorResponse>();
            var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
            t2.Wait();
            ErrorResponse? errorResponse = t2.Result;
            if (errorResponse != null) registrationResult.Error = errorResponse.error;
            return registrationResult;
        }

        public String ValidateEmail(string Email, string Code)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email),
                new KeyValuePair<string,string>("code", Code)
            });

            var t1 = Task.Run(() => _http.PostAsync("auth/validateemail", content));
            t1.Wait();
            HttpResponseMessage resp = t1.Result;

            if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return "";
            var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
            t2.Wait();
            ErrorResponse? errorResponse = t2.Result;
            if (errorResponse != null) return errorResponse.error;
            else return "";
        }

        public String SendEmail(string Email)
        {
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("email", Email)
            });

            var t1 = Task.Run(() => _http.PostAsync("auth/sendemail", content));
            t1.Wait();
            HttpResponseMessage resp = t1.Result;

            if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return "";
            var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
            t2.Wait();
            ErrorResponse? errorResponse = t2.Result;
            if (errorResponse != null) return errorResponse.error;
            else return "";
        }

        public UserResult GetLoggedInUser()
        {
            try
            {
                SetUserToken();
                var t1 = Task.Run(() => _http.GetAsync("users"));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                UserResult userResult = new();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var t3 = Task.Run(() => resp.Content.ReadFromJsonAsync<User>());
                    t3.Wait();
                    User? userResponse = t3.Result;
                    if (userResponse != null)
                    {
                        userResult.UserInfo = userResponse;
                    }
                    return userResult;
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public UserResult GetUser(string UserId)
        {
            try
            {
                SetUserToken();
                var t1 = Task.Run(() => _http.GetAsync("users/" + UserId));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                UserResult userResult = new();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var t3 = Task.Run(() => resp.Content.ReadFromJsonAsync<User>());
                    t3.Wait();
                    User? userResponse = t3.Result;
                    if (userResponse != null)
                    {
                        userResult.UserInfo = userResponse;
                    }
                    return userResult;
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public AvatarListResult GetAvatarsList()
        {
            try
            {
                SetUserToken();
                var t1 = Task.Run(() => _http.GetAsync("users/avatars/list"));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                AvatarListResult avatarListResult = new();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var t3 = Task.Run(() => resp.Content.ReadFromJsonAsync<AvatarListResponse>());
                    t3.Wait();
                    AvatarListResponse? avatarListResponse = t3.Result;
                    if (avatarListResponse != null) avatarListResult.AvatarList = avatarListResponse.avatarList;
                    return avatarListResult;
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public string SaveUserSettings(string FirstName, string LastName, string AvatarUrl)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("firstName", FirstName),
                    new KeyValuePair<string,string>("lastName", LastName),
                    new KeyValuePair<string,string>("avatarUrl", AvatarUrl)
                });

                var t1 = Task.Run(() => _http.PutAsync("users/", content));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public UserAssigneesResult GetUserAssignees()
        {
            try
            {
                SetUserToken();
                var t1 = Task.Run(() => _http.GetAsync("TM/assignees"));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                UserAssigneesResult assigneesResult = new();

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return assigneesResult;
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var t3 = Task.Run(() => resp.Content.ReadFromJsonAsync<User[]?>());
                    t3.Wait();
                    User[]? assigneesResponse = t3.Result;
                    if (assigneesResponse != null) assigneesResult.Assignees = assigneesResponse;
                    return assigneesResult;
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public string AddAssignee(string Email)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("email", Email),
                });

                var t1 = Task.Run(() => _http.PostAsync("TM/assignees", content));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "";
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public TasksResult GetTasks(string AssigneeId)
        {
            try
            {
                SetUserToken();
                var t1 = Task.Run(() => _http.GetAsync("TM/tasks/" + AssigneeId));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                TasksResult taskResult = new();

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return taskResult;
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var t3 = Task.Run(() => resp.Content.ReadFromJsonAsync<TMTask[]>());
                    t3.Wait();
                    TMTask[]? tasksResponse = t3.Result;
                    if (tasksResponse != null)
                    {
                        taskResult.Tasks = tasksResponse;
                        foreach (TMTask task in taskResult.Tasks)
                        {
                            var result = GetUser(task.owner);
                            if (result.Error == "")
                            {
                                task.ownerName = result.UserInfo.fullName;
                            }
                        }
                    }
                    return taskResult;
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public string AddTask(TMTask task)
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

                var t1 = Task.Run(() => _http.PostAsync("TM/tasks", content));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "";
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public string UpdateTask(TMTask task)
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

                var t1 = Task.Run(() => _http.PutAsync("TM/tasks", content));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public TaskNotesResult GetTaskNotes(string TaskId)
        {
            try
            {
                SetUserToken();
                var t1 = Task.Run(() => _http.GetAsync("TM/tasknotes/" + TaskId));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                TaskNotesResult taskNotesResult = new();

                if (resp.StatusCode == System.Net.HttpStatusCode.NoContent) return taskNotesResult;
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //var value = resp.Content.ReadAsStringAsync();
                    var t3 = Task.Run(() => resp.Content.ReadFromJsonAsync<TMTaskNote[]>());
                    t3.Wait();
                    TMTaskNote[]? taskNotesResponse = t3.Result;
                    if (taskNotesResponse != null)
                    {
                        taskNotesResult.TaskNotes = taskNotesResponse;
                    }
                    return taskNotesResult;
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public string AddTaskNote(TMTaskNote taskNote)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("task", taskNote.task),
                    new KeyValuePair<string,string>("enteredDate", taskNote.enteredDate),
                    new KeyValuePair<string,string>("note", taskNote.note),
                });

                var t1 = Task.Run(() => _http.PostAsync("TM/tasknotes", content));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "";
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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

        public string UpdateTaskNote(TMTaskNote taskNote)
        {
            try
            {
                SetUserToken();
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("_id", taskNote._id),
                    new KeyValuePair<string,string>("enteredDate", taskNote.enteredDate),
                    new KeyValuePair<string,string>("note", taskNote.note),
                });

                var t1 = Task.Run(() => _http.PutAsync("TM/tasknotes", content));
                t1.Wait();
                HttpResponseMessage resp = t1.Result;

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "";
                }
                var t2 = Task.Run(() => resp.Content.ReadFromJsonAsync<ErrorResponse>());
                t2.Wait();
                ErrorResponse? errorResponse = t2.Result;
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
