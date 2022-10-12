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
    public class EFActivityRepository: EFRepositoryAsync<Activity>, IActivityRepository
    {
        private readonly AllocationsDbContext _context;

        public EFActivityRepository(AllocationsDbContext context) : base(context, () => context.Activities)
        {
            _context = context;
        }
    }
}
