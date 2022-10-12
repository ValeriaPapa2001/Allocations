using Allocations.Core.BusinnessLogic;
using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using Allocations.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef.Repositories
{
    public class EFJobRepository : EFRepositoryAsync<Job> , IJobRepository
    {
        private readonly AllocationsDbContext _context;
        public EFJobRepository(AllocationsDbContext context): base(context, () => context.Jobs)
        {
            _context = context;
        }
    }
}
