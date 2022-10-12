using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef.Repositories
{
    public class EFEmployeeRepository: EFRepositoryAsync<Employee>, IEmployeeRepository

    {
        private readonly AllocationsDbContext _context;

        public EFEmployeeRepository(AllocationsDbContext context) : base(context, () => context.Employees)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAlphabeticOrder()
        {
            return _context.Employees.OrderBy(e => (e.LastName + e.FirstName)).ToList();
        }


    }
}
