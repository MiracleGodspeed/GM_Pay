using FakeItEasy;
using FluentAssertions;
using GMPay.Api.Controllers;
using GMPay.Core.Dtos;
using GMPay.Core.Interfaces;
using GMPay.Core.Services;
using GMPay.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMPPay.Tests.Controllers
{
    public class MerchantControllerTests
    {
        [Fact]
        public async Task CreateMerchant_ReturnsOkResult()
        {
            //Arrange
            var merchantServiceMock = new Mock<IMerchantService>();
            var controller = new MerchantController(merchantServiceMock.Object);

            var createMerchantDto = A.Fake<CreateMerchantDto>();

            // Act
            var result = await controller.CreateMerchant(createMerchantDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MerchantList_ReturnsOkResult()
        {
            // Arrange
            var merchantServiceMock = new Mock<IMerchantService>();
            var controller = new MerchantController(merchantServiceMock.Object);
            int pageNumber = 1; 
            int pageSize = 10;

            // Act
            var result = await controller.MerchantList(pageNumber, pageSize);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }

}
