using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(string fullName, string sex, DateTime dateOfBirth, decimal income);
        Task<User> GetUserAsync(int userId);
    }
}
