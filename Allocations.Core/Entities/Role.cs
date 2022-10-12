using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}
