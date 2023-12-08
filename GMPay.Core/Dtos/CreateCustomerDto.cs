using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Dtos
{
    public record CreateCustomerDto
    {
        public string NationalIDNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string CustomerNumber { get; set; }
    }
}
