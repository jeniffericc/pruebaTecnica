using PruebaTecnica.BusinessLogic.Interfaces;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(string fullName, string sex, DateTime dateOfBirth, decimal income)
        {
            var user = new User
            {
                FullName = fullName,
                Sex = sex,
                DateOfBirth = dateOfBirth,
                Incomes = income
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }
    }
}
