using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PruebaTecnica.Infrastructure.Data
{
    public class PruebaTecnicaDbContext : DbContext
    {
        public PruebaTecnicaDbContext(DbContextOptions<PruebaTecnicaDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BankAccount>()
                .HasOne(b => b.User)
                .WithMany(u => u.BankAccounts)
                .HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
