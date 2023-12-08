using FakeItEasy;
using GMPay.Api.Controllers;
using GMPay.Core.Dtos;
using GMPay.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPPay.Tests.Controllers
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task CreateCustomer_ReturnsOkResult()
        {
            //Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomerController(customerServiceMock.Object);

            var createCustomerDto = A.Fake<CreateCustomerDto>();

            // Act
            var result = await controller.CreateCustomer(createCustomerDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MakePayment_ReturnsOkResult()
        {
            //Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomerController(customerServiceMock.Object);

            var makePaymentDto = A.Fake<CustomerPaymentDto>();

            // Act
            var result = await controller.MakePayment(makePaymentDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task TransactionsByCustomerId_ReturnsOkResult()
        {
            // Arrange
            var merchantServiceMock = new Mock<ICustomerService>();
            var controller = new CustomerController(merchantServiceMock.Object);
            Guid customerId = Guid.NewGuid();

            // Act
            var result = await controller.TransactionsByCustomerId(customerId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
