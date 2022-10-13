using Allocations.Core.Entities;
using Allocations.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface IUserRepository : IRepositoryAsync<User>
    {
        Task<User> FindUserByEmailAsync(string email);
    }

}
