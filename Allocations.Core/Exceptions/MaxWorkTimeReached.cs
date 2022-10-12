using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Exceptions
{
    public class MaxWorkTimeReached : Exception
    {
        public Employee Employee { get; set; }
        public const int maxHour = 10;


        public MaxWorkTimeReached(Employee employee) : base($"Employee {employee.FirstName} {employee.LastName}" +
            $" reached the allowed daily hour limit of {maxHour} hours.")
        {
            Employee = employee;
        }
    }
}
