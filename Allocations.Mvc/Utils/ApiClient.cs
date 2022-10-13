using Allocations.Mvc.DataContracts;
using Newtonsoft.Json;
using System.Text;

namespace Allocations.Mvc.Utils
{
    public class ApiClient : IDisposable
    {
        private HttpClient _httpClient;
        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7110");
        }
        #region Employee
        public async Task<IEnumerable<EmployeeContract>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync("api/Employee");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<EmployeeContract> employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeContract>>(content);
                return employees;
            }
            return new List<EmployeeContract>();
        }

        public async Task<EmployeeContract> GetEmployee(int id)
        {
            var response = await _httpClient.GetAsync($"api/Employee/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                EmployeeContract employee = JsonConvert.DeserializeObject<EmployeeContract>(content);
                return employee;
            }
            return null;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/{id}");
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> InsertEmployee(EmployeeContract employee)
        {
            var content = new JsonContent(employee);
            var response = await _httpClient.PostAsync("api/Employee", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEmployee(EmployeeContract employee)
        {
            string json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Employee/{employee.Id}", content);
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region Role
        public async Task<IEnumerable<RoleContract>> GetAllRoles()
        {
            var response = await _httpClient.GetAsync("api/Role");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<RoleContract> roles = JsonConvert.DeserializeObject<IEnumerable<RoleContract>>(content);
                return roles;
            }
            return new List<RoleContract>();
        }
        #endregion

        #region Activity

        public async Task<IEnumerable<ActivityContract>> GetAllActivities()
        {
            var response = await _httpClient.GetAsync("api/Activity");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<ActivityContract> activities = JsonConvert.DeserializeObject<IEnumerable<ActivityContract>>(content);
                return activities;
            }
            return new List<ActivityContract>();
        }
        #endregion

        #region Job
        public async Task<IEnumerable<JobContract>> GetAllJobs()
        {
            var response = await _httpClient.GetAsync("api/Job");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<JobContract> jobs = JsonConvert.DeserializeObject<IEnumerable<JobContract>>(content);
                return jobs;
            }
            return new List<JobContract>();
        }
        #endregion

        #region TimeSheet 

        public async Task<IEnumerable<TimeSheetContract>> GetAllTimeSheets()
        {
            var response = await _httpClient.GetAsync("api/TimeSheet");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<TimeSheetContract> timeSheets = JsonConvert.DeserializeObject<IEnumerable<TimeSheetContract>>(content);
                return timeSheets;
            }
            return new List<TimeSheetContract>();
        }

        public async Task<TimeSheetContract> GetTimeSheet(int id)
        {
            var response = await _httpClient.GetAsync($"api/TimeSheet/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                TimeSheetContract timesheet = JsonConvert.DeserializeObject<TimeSheetContract>(content);
                return timesheet;
            }
            return null;

        }

        public async Task<bool> InsertTimeSheet(TimeSheetContract timeSheet)
        {
            var content = new JsonContent(timeSheet);
            var response = await _httpClient.PostAsync("api/TimeSheet", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTimeSheet(TimeSheetContract timeSheet)
        {
            string json = JsonConvert.SerializeObject(timeSheet);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/TimeSheet/{timeSheet.Id}", content);
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region User
        public async Task<string> CheckLoginAsync(string email, string password)
        {
            var content = new JsonContent(new
            {
                Email = email,
                Password = password
            });

            var response = await _httpClient.PostAsync("api/User/Login", content);
            var content1 = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CudResultContract>(content1);
            return result.Message;
        }

        public async Task<UserContract> GetUserByEmailAsync(string email)
        {
            var response = await _httpClient.GetAsync($"api/User/Email/{email}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserContract>(content);
            }
            return null;

            #endregion

            
        }
        public void Dispose()
        {
            _httpClient.Dispose();
            _httpClient = null;
        }
    }
}
    

