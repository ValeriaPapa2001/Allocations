namespace Allocations.Mvc.Models
{
    public class TimeSheetGridViewModel
    {
        public int Id { get; set; }

        public DateTime StartActivity { get; set; }

        public TimeSpan HourActivity { get; set; }

        public string EmployeeName { get; set; }

        public string CustomerName { get; set; }

        public string ActivityName { get; set; }

        public string JobName { get; set; }

        
    }
}
