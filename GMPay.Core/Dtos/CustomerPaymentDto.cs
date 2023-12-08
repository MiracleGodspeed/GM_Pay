using GMPay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Dtos
{
    public record CustomerPaymentDto
    {
        public Guid CustomerId { get; set; }
        //public string CustomerNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
    }
}
