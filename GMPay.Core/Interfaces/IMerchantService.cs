using GMPay.Core.Dtos;
using GMPay.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Interfaces
{
    public interface IMerchantService
    {
        Task<BaseResponse> CreateMerchantRecord(CreateMerchantDto dto);
        Task<BaseResponse> AllMerchantList(int pageNumber, int pageSize);
    }
}
