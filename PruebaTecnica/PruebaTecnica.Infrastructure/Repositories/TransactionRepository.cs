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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PruebaTecnicaDbContext _context;

        public TransactionRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> GetByIdAsync(int transactionId)
        {
            return await _context.Transaction.FirstOrDefaultAsync(a => a.TransactionId == transactionId);
        }
    }
}
