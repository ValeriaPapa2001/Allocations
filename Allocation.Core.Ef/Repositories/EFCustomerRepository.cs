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
    public class EFCustomerRepository: EFRepositoryAsync<Customer>, ICustomerRepository
    {
        private readonly AllocationsDbContext _context;
        public EFCustomerRepository(AllocationsDbContext context) : base(context, () => context.Customers)
        {
            _context = context;
        }
    }
}
