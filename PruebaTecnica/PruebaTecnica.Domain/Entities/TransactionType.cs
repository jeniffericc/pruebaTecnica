using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Entities
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
