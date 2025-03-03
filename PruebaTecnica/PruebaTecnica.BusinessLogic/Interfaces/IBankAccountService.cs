using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BusinessLogic.Interfaces
{
    public interface IBankAccountService
    {
        Task<BankAccount> CreateBankAccountAsync(int userId, string accountNumber, decimal balance);
        Task<bool> UpdateBankAccountBalanceAsync(int bankAccountId, decimal Amount, string accountNumber, int userId);
        Task<BankAccount> GetBankAccountAsync(string accountNumber);
        Task<BankAccount> GetBankAccountByIdAsync(int bankAccountId);
        Task<decimal> GetBalanceAsync(string accountNumber);
    }
}
