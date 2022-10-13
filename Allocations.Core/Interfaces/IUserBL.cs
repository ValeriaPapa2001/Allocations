using Allocations.Core.Entities;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface IUserBL
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);

        Task<CudResult> CheckLoginAsync(string email, string password);

        Task<CudResult> RegisterNewAccount(string email, string password);

    }
}
