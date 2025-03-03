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
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly ITransactionTypeRepository _ttRepository;

        public TransactionTypeService(ITransactionTypeRepository ttRepository)
        {
            _ttRepository = ttRepository;
        }

        public async Task<TransactionType> CreateTransactionTypeAsync(string name, int isDeleted)
        {
            var transationType = new TransactionType
            {
                Name = name,
                IsDeleted = isDeleted
            };

            await _ttRepository.AddAsync(transationType);
            return transationType;
        }

        public async Task<TransactionType> GetTransactionTypeAsync(int transationTypeId)
        {
            return await _ttRepository.GetByIdAsync(transationTypeId);
        }
    }
}
