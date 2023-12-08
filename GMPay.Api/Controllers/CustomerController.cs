using GMPay.Core.Dtos;
using GMPay.Core.Interfaces;
using GMPay.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
        {
            return Ok(await _customerService.CreateCustomerRecord(dto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CustomerSignIn(string customerNumber)
        {
            return Ok(await _customerService.ValidateCustomer(customerNumber));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CustomerList(int pageNumber, int pageSize)
        {
            return Ok(await _customerService.GetAllCustomerList(pageNumber, pageSize));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> MakePayment(CustomerPaymentDto dto)
        {
            return Ok(await _customerService.CustomerMakePayment(dto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TransactionsByCustomerId(Guid customerId)
        {
            return Ok(await _customerService.CustomerTransactionsByCustomerId(customerId));
        }
    }
}
