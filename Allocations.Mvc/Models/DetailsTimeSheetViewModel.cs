namespace Allocations.Mvc.Models
{
    public class DetailsTimeSheetViewModel
    {
        public int Id { get; set; }

        public DateTime StartActivity { get; set; }

        public DateTime HourActivity { get; set; }

        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public string JobName { get; set; }
        public int IdJob { get; set; }

    }
}
