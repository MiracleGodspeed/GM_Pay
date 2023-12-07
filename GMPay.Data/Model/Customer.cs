using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Data.Model
{
    public class Customer : BaseModel
    {
        public string NationalIDNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public Guid CustomerNumber { get; set; }
    }
}
