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
    public class EFRoleRepository: EFRepositoryAsync<Role>, IRoleRepository
    {
        private readonly AllocationsDbContext _context;
        public EFRoleRepository(AllocationsDbContext context) : base(context, () => context.Roles)
        {
            _context = context;
        }
    }
}
