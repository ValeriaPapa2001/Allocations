using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class RoleBL : IRoleBL
    {
        private readonly IRoleRepository _roleRepository;
        public RoleBL(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.FetchAsync();
        }
    }
}
