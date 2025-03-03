using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Tests.Data;

namespace PruebaTecnica.Tests.Repositories
{
    public class UserRepository
    {
        private readonly TestsDbContext _context;
        private readonly UserRepository _repository;
        public UserRepository(TestsDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(string fullName)
        {
            var user = new User { FullName = fullName };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }

}
