using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Incomes { get; set; }

        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

    }
}
