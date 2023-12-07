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
        public string DateofEstablishment { get; set; }
        public Guid MerchantNumber { get; set; }
        public Guid? AverageTransactionVolume { get; set; }
    }
}
