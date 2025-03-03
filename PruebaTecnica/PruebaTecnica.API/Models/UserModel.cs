using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.API.Models
{
    public class CreateUserModel
    {
        public string FullName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Income { get; set; }
    }
}
