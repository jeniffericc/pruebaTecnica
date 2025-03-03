using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;


namespace PruebaTecnica.Tests.Data
{
    public class TestsDbContext : DbContext
    {
        public TestsDbContext(DbContextOptions<TestsDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
    }
}
