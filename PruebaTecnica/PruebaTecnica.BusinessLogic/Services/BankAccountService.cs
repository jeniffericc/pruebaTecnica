using PruebaTecnica.BusinessLogic.Interfaces;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BusinessLogic.Services
{
    public class BankAccountService : IBankAccountService
    {

        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<BankAccount> CreateBankAccountAsync(int userId, string accountNumber, decimal balance)
        {
            var bankAccount = new BankAccount
            {
                UserId = userId,
                AccountNumber = accountNumber,
                Balance = balance
            };

            await _bankAccountRepository.AddAsync(bankAccount);
            return bankAccount;
        }

        public async Task<bool> UpdateBankAccountBalanceAsync(int bankAccountId, decimal balance, string accountNumber, int userId)
        {
            var bankAccount = await _bankAccountRepository.GetByIdAsync(bankAccountId);

            if (bankAccount == null || bankAccount.AccountNumber != accountNumber || bankAccount.UserId != userId)
            {
                return false;
            }

            bankAccount.Balance = balance;

            var bankAccountUpdated = await _bankAccountRepository.UpdateBalanceAsync(bankAccount);
            return bankAccountUpdated;
        }

        public async Task<BankAccount> GetBankAccountByIdAsync(int bankAccountId)
        {
            var bankAccount = await _bankAccountRepository.GetByIdAsync(bankAccountId);
            return bankAccount;
        }

        public async Task<BankAccount> GetBankAccountAsync(string accountNumber)
        {
            var bankAccount = await _bankAccountRepository.GetByAccountNumberAsync(accountNumber);
            return bankAccount;
        }
        public async Task<decimal> GetBalanceAsync(string accountNumber)
        {
            var bankAccount = await _bankAccountRepository.GetByAccountNumberAsync(accountNumber);
            return bankAccount?.Balance ?? 0m;
        }
    }
}
