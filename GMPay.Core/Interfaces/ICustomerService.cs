using GMPay.Core.Dtos;
using GMPay.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseResponse> ValidateCustomer(string CustomerNumber);
        Task<BaseResponse> CreateCustomerRecord(CreateCustomerDto dto);
        Task<BaseResponse> GetAllCustomerList(int pageNumber, int pageSize);
        Task<BaseResponse> CustomerMakePayment(CustomerPaymentDto dto);
        Task<BaseResponse> CustomerTransactionsByCustomerId(Guid customerId);
    }
}
