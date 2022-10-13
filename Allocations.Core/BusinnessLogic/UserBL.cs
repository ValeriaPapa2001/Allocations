using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;
        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CudResult> CheckLoginAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
                return new CudResult($"User '{email}' not found.");

            string hashedPassword = CryptoUtils.ComputeHash(password, "SHA256");
            if (!user.Password.Equals(hashedPassword))
                return new CudResult($"User '{email}' password is wrong.");

            return new CudResult();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return await _userRepository.FindUserByEmailAsync(email);
        }

        public async Task<CudResult> RegisterNewAccount(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return new CudResult("Email is null or empty");

            if (string.IsNullOrEmpty(password))
                return new CudResult("Password is null or empty");

            var employee = new User
            {
                Email = email,
                Roll = Roll.Employee,
                Password = CryptoUtils.ComputeHash(password, "SHA256")
            };
            return await _userRepository.InsertAsync(employee);
        }

    }
}
