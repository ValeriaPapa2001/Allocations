using Allocations.Core.Entities;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface IEmployeeBL
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAlphabeticOrderAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<CudResult> UpdateEmployeeAsync(Employee employee);
        Task<CudResult> DeleteEmployeeAsync(int id);

        Task<CudResult> InsertEmployeeAsync(Employee employee);
    }
}
