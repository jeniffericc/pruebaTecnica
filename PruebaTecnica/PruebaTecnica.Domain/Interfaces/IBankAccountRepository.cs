using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Interfaces
{
    public interface IBankAccountRepository
    {
        Task AddAsync(BankAccount bankAccount);
        Task<bool> UpdateBalanceAsync(BankAccount bankAccount);
        Task<BankAccount> GetByAccountNumberAsync(string accountNumber);
        Task<BankAccount> GetByIdAsync(int bankAccountId);
    }
}
