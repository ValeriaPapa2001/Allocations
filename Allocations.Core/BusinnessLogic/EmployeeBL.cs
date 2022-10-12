using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRepository _empRepo;

        public EmployeeBL(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<CudResult> DeleteEmployeeAsync(int id)
        {
            return await _empRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAlphabeticOrderAsync()
        {
            return await _empRepo.GetAllEmployeesAlphabeticOrder();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _empRepo.GetByIdAsync(id);
        }

        public async Task<CudResult> InsertEmployeeAsync(Employee employee)
        {
            return await _empRepo.InsertAsync(employee);
        }

        public async Task<CudResult> UpdateEmployeeAsync(Employee employee)
        {
            return await _empRepo.UpdateAsync(employee);
        }
    }
}
