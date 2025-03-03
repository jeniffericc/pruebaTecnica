using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BusinessLogic.Interfaces
{
    public interface ITransactionTypeService
    {
        Task<TransactionType> CreateTransactionTypeAsync(string name, int isDeleted);
        Task<TransactionType> GetTransactionTypeAsync(int transactionTypeId);
    }
}
