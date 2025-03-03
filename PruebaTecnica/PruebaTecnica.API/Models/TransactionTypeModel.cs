using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.API.Models
{
    public class CreateTransactionTypeModel
    {
        public string Name { get; set; }
        public int IsDeleted { get; set; }
    }
}
