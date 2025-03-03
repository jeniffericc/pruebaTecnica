using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PruebaTecnicaDbContext _context;

        public UserRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.User.Include(c => c.BankAccounts).FirstOrDefaultAsync(c => c.Id == userId);
        }
    }
}
