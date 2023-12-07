using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Data.Model
{
    public class Merchant : BaseModel
    {
        public string BusinessName { get; set; }
        public string BusinessID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactSurname { get; set; }
        public DateTime DateofEstablishment { get; set; }
        public string MerchantNumber { get; set; }
        public decimal? AverageTransactionVolume { get; set; }
    }
}
