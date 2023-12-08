using GMPay.Core.Dtos;
using GMPay.Core.Infrastructures;
using GMPay.Core.Interfaces;
using GMPay.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPay.Core.Services
{
    public class MerchantService : Repository<MerchantService>, IMerchantService
    {
        public MerchantService(GMPayContext context) : base(context)
        {

        }

        public async Task<BaseResponse> CreateMerchantRecord(CreateMerchantDto dto)
        {
            try
            {
                var doesMerchantExist = await _context.Merchant.Where(x => x.BusinessID == dto.BusinessID).FirstOrDefaultAsync();
                if (doesMerchantExist == null)
                {
                    //validate that the business age may not be less than 1 year
                    if (!IsBusinessEstablishmentDateValid(dto.DateofEstablishment))
                    {
                        return new BaseResponse() { IsSuccess = false, Message = "Business establishment date should not be less that one year..." };
                    }

                    Merchant merchant = new Merchant()
                    {
                        BusinessID = dto.BusinessID,
                        BusinessName = dto.BusinessName,
                        DateofEstablishment = dto.DateofEstablishment,
                        ContactFirstName = dto.ContactFirstName,
                        ContactSurname = dto.ContactSurname,
                        AddedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                        MerchantNumber = Utility.RandomString(8),
                        AverageTransactionVolume = dto.AverageTransactionVolume,
                        Active = true
                    };
                    _context.Merchant.Add(merchant);
                    await _context.SaveChangesAsync();
                    return new BaseResponse() { IsSuccess = true, Message = "merchant created!", Data = merchant };
                }
                else
                {
                    return new BaseResponse() { IsSuccess = false, Message = "Merchant with the businessID alreasy exists!" };
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponse> AllMerchantList(int pageNumber, int pageSize)
        {
            try
            {
                var allMerchants = await _context.Merchant
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                return new BaseResponse() { IsSuccess = true, Data = allMerchants };
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public bool IsBusinessEstablishmentDateValid(DateTime establishmentDate)
        {
            if((DateTime.Now.Year - establishmentDate.Year) < 1)
            {
                return false;
            }
            return true;
        }
    }
}
