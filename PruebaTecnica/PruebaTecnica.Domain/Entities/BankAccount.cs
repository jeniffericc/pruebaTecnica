using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; } = 0.0m;
        public string AccountNumber { get; set; }

        public User User { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
