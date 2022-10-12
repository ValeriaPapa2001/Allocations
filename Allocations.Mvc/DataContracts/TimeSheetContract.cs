using Allocations.Core.Entities;

namespace Allocations.Mvc.DataContracts
{
    public class TimeSheetContract
    {
        public int Id { get; set; }
        public DateTime StartActivity { get; set; }
        public TimeSpan HourActivity { get; set; }

        public int IdEmployee { get; set; }
        public int IdCustomer { get; set; }
        public int IdActivity { get; set; }
        public int IdJob { get; set; }


        public EmployeeContract Employee { get; set; }
        public Customer Customer { get; set; }
        public ActivityContract Activity { get; set; }
        public JobContract Job { get; set; }
    }
}
