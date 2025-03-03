using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(int userId);
    }
}
