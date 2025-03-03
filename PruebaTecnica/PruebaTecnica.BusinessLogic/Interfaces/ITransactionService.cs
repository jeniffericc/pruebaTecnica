using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BusinessLogic.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(int bankAccount, int amount, DateTime date, int transactionTypeId);
        Task<Transaction> GetTransactionAsync(int transactionId);
    }
}
