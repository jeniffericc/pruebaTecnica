using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.API.Models
{
    public class CreateTransactionModel
    {
        public int BankAccount { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
