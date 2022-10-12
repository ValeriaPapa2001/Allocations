using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Entities
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public DateTime StartActivity { get; set; }
        public TimeSpan HourActivity { get; set; }

        public int IdEmployee { get; set; }
        public int IdCustomer { get; set; }
        public int IdActivity { get; set; }
        public int IdJob { get; set; }


        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public Activity Activity { get; set; }
        public Job Job { get; set; }
    }
}
