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
    public class UserRepositoryTests
    {
        private readonly TestsDbContext _context;
        private readonly UserRepository _repository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TestsDbContext>()
                .UseInMemoryDatabase(databaseName: "pruebaTecnica")
                .Options;

            _context = new TestsDbContext(options);
            _repository = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task CreateUserAsync_ShouldAddUserToDatabase()
        {
            var newUser = await _repository.CreateUserAsync("Luis Solis");

            var user = await _context.User.FindAsync(newUser.Id);
            Assert.NotNull(user);
            Assert.Equal("Luis Solis", user.FullName);
        }
    }
}
