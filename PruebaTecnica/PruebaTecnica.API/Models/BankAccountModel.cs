using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.API.Models
{
    public class CreateBankAccountModel
    {
        public string AccountNumber { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
