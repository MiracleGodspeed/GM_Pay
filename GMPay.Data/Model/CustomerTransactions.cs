using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Data.Model
{
    public class CustomerTransactions : BaseModel
    {
        public Guid CustomerId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public bool IsSuccessful { get; set; }



        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
