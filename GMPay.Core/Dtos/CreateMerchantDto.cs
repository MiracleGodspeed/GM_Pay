using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Dtos
{
    public record CreateMerchantDto
    {
        public string BusinessName { get; set; }
        public string BusinessID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactSurname { get; set; }
        public DateTime DateofEstablishment { get; set; }
        public decimal? AverageTransactionVolume { get; set; }
    }
}
