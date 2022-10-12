using Allocations.Core.Entities;
using Allocations.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface IEmployeeRepository : IRepositoryAsync<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAlphabeticOrder();

    }
}
