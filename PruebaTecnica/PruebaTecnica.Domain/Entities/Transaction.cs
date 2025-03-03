using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int BankAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int TransactionTypeId { get; set; }

        public BankAccount BankAccount { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
