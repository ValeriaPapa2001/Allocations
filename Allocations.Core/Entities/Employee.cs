using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } 
        public DateTime StartDate { get; set; }
        public decimal HourCost { get; set; }


        public int IdRole { get; set; }
        public Role Role { get; set; }

        public IList<TimeSheet> TimeSheets { get; set; }

    }

}
