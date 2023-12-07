using GMPay.Core.Dtos;
using GMPay.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMPay.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class MerchantController  : ControllerBase
        {
            private readonly IMerchantService _merchantService;
        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMerchant(CreateMerchantDto dto)
        {
            return Ok(await _merchantService.CreateMerchantRecord(dto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MerchantList(int pageNumber, int pageSize)
        {
            return Ok(await _merchantService.AllMerchantList(pageNumber, pageSize));
        }
    }
}
