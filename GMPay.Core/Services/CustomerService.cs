using GMPay.Core.Dtos;
using GMPay.Core.Interfaces;
using GMPay.Data;
using GMPay.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Services
{
    public class CustomerService : Repository<MerchantService>, ICustomerService
    {
        public CustomerService(GMPayContext context) : base(context)
        {

        }

        public async Task<BaseResponse> ValidateCustomer(string CustomerNumber)
        {
            try
            {
                var existingRecord = await _context.Customer.Where(x => x.CustomerNumber.Trim() == CustomerNumber.Trim()).FirstOrDefaultAsync();
                if (existingRecord != null)
                {
                    return new BaseResponse() { Data = existingRecord, IsSuccess = true };
                }
                return new BaseResponse() { Data = existingRecord, IsSuccess = false };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponse> CreateCustomerRecord(CreateCustomerDto dto)
        {
            try
            {
                var doesCustomerWithNumberExisting = await _context.Customer.Where(x => x.CustomerNumber == dto.CustomerNumber || x.NationalIDNumber == dto.NationalIDNumber).FirstOrDefaultAsync();
                if (doesCustomerWithNumberExisting != null)
                {
                    return new BaseResponse() { IsSuccess = false, Message = "A Customer with the phone number/NIN provided already exists" };
                }
                Customer customer = new Customer()
                {
                    FirstName = dto.FirstName,
                    Surname = dto.Surname,
                    NationalIDNumber = dto.NationalIDNumber,
                    CustomerNumber = dto.CustomerNumber,
                    DateofBirth = dto.DateofBirth,
                    AddedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    Active = true
                };
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
                return new BaseResponse() { IsSuccess = true, Data = customer, Message = "customer created!" };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BaseResponse> GetAllCustomerList(int pageNumber, int pageSize)
        {
            var customers = await _context.Customer
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                
            return new BaseResponse() { IsSuccess = true, Data = customers  };
        }
        public async Task<BaseResponse> CustomerMakePayment(CustomerPaymentDto dto)
        {
            try
            {
                var getCustomer = await _context.Customer.Where(x => x.Id == dto.CustomerId).FirstOrDefaultAsync();
                if (getCustomer != null)
                {
                    if (!IsCustomerEligibleForTransaction(dto.TransactionCategory, getCustomer.DateofBirth))
                        return new BaseResponse() { IsSuccess = false, Message = "Age requirement for this transaction was not met" };

                    CustomerTransactions customerTransaction = new CustomerTransactions()
                    {
                        CustomerId = dto.CustomerId,
                        TransactionAmount = dto.Amount,
                        TransactionDate = DateTime.Now,
                        AddedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                        Active = true,
                        IsSuccessful = true
                    };
                    _context.Add(customerTransaction);
                    await _context.SaveChangesAsync();
                    return new BaseResponse { IsSuccess = true, Data = customerTransaction };
                }
                return new BaseResponse { IsSuccess = false, Data = null };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BaseResponse> CustomerTransactionsByCustomerId(Guid customerId)
        {
            var getTransactions = await _context.CustomerTransactions.Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return new BaseResponse() {IsSuccess = true, Data = getTransactions };
        }
        public bool IsCustomerEligibleForTransaction(TransactionCategory category, DateTime dateOfBirth)
        {
            long adultAge = 18;
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateOfBirth.Year;

            switch (category)
            {
                case TransactionCategory.DstvSubscriptionForChildren: 
                        if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
                        {
                            age--;
                        }

                        return age < adultAge;

                case TransactionCategory.DstvSubscriptionForAdult:
                    if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
                    {
                        age--;
                    }
                    return age > adultAge;

                default: return false;
            }
        }
    }
}
