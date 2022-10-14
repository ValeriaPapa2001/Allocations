using Allocations.Mvc.DataContracts;
using Newtonsoft.Json;

namespace Allocations.Mvc.Utils
{
    public class ChartClient
    {
        private HttpClient _httpClient;

        public ChartClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7125");
        }

        public async Task<IEnumerable<ChartEmployeeContract>> GetEmployees()
        {
            var response = await _httpClient.GetAsync("api/employee");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<ChartEmployeeContract> customers = JsonConvert.DeserializeObject<IEnumerable<ChartEmployeeContract>>(content);
                return customers;
            }
            return new List<ChartEmployeeContract>();
        }

        public async Task<IEnumerable<TimeSheetContract>> GetMonthlyTimesheetByEmployeeId(int id)
        {
            var response = await _httpClient.GetAsync($"api/timesheet/employee/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<TimeSheetContract> timeSheet = JsonConvert.DeserializeObject<IEnumerable<TimeSheetContract>>(content);
                return timeSheet;
            }
            return new List<TimeSheetContract>();
        }

    }
}
