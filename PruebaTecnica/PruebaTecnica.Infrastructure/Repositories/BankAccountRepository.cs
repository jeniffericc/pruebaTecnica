using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly PruebaTecnicaDbContext _context;

        public BankAccountRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BankAccount bankAccount)
        {
            await _context.BankAccount.AddAsync(bankAccount);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> UpdateBalanceAsync(BankAccount bankAccount)
        {
            _context.BankAccount.Update(bankAccount);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<BankAccount> GetByAccountNumberAsync(string accountNumber)
        {
            return await _context.BankAccount.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }
        public async Task<BankAccount> GetByIdAsync(int banAccountId)
        {
            return await _context.BankAccount.FirstOrDefaultAsync(a => a.Id == banAccountId);
        }

    }
}
