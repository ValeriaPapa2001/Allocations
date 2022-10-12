using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Mock
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<CudResult> DeleteAsync(object id)
        {
            var employee = await GetByIdAsync(id);
            EmployeeStorage.Employees.Remove(employee);
            return new CudResult() ;
        }

        public async Task<IEnumerable<Employee>> FetchAsync(Func<Employee, bool> filter = null)
        {
            return EmployeeStorage.Employees.Where(filter).ToList();
                              
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAlphabeticOrder()
        {
            return EmployeeStorage.Employees.OrderBy(e=> (e.LastName + e.FirstName)).ToList();
        }

        public async Task<Employee> GetByIdAsync(object id)
        {
            return EmployeeStorage.Employees.FirstOrDefault(e=> e.Id==(int)id);
        }

        public async Task<CudResult> InsertAsync(Employee entity)
        {
            int newId = EmployeeStorage.Employees.Max(x => x.Id) + 1;
            entity.Id = newId;
            EmployeeStorage.Employees.Add(entity);
            return new CudResult();
        }

        public async Task<CudResult> UpdateAsync(Employee entity)
        {
            var employee = EmployeeStorage.Employees.FirstOrDefault(x => x.Id == entity.Id);
            EmployeeStorage.Employees.Remove(employee);
            EmployeeStorage.Employees.Add(entity);
            return new CudResult();
        }
    }
}
