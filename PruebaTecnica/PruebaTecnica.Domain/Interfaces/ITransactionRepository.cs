using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<Transaction> GetByIdAsync(int transactionId);
    }
}
