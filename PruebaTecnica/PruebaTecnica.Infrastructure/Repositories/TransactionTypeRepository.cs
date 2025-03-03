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
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly PruebaTecnicaDbContext _context;

        public TransactionTypeRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TransactionType transactionType)
        {
            await _context.TransactionType.AddAsync(transactionType);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionType> GetByIdAsync(int transactionTypeId)
        {
            return await _context.TransactionType.FirstOrDefaultAsync(a => a.TransactionTypeId == transactionTypeId);
        }
    }
}
