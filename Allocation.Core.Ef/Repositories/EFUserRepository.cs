using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef.Repositories
{
    public class EFUserRepository : EFRepositoryAsync<User>, IUserRepository
    {
        private readonly AllocationsDbContext _dbContext;
        public EFUserRepository(AllocationsDbContext dbContext) : base(dbContext, () => dbContext.Users)
        {
            _dbContext = dbContext;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }

}
