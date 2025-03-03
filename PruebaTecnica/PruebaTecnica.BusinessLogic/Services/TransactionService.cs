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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> CreateTransactionAsync(int bankAccount, int amount, DateTime date, int transactionTypeId)
        {
            var transaction = new Transaction
            {
                BankAccountId = bankAccount,
                Amount = amount,
                Date = date,
                TransactionTypeId = transactionTypeId
            };

            await _transactionRepository.AddAsync(transaction);

            return transaction;
        }


        public async Task<Transaction> GetTransactionAsync(int transactionId)
        {
            return await _transactionRepository.GetByIdAsync(transactionId);
        }
    }
}
