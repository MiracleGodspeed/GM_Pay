using GMPay.Core.Dtos;
using GMPay.Core.Services;
using GMPay.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GMPay.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task CreateMerchant_ReturnsOkResultWhenMerchantCreated()
        {
            //var merchantServiceMock = new Mock<MerchantService>();
            //var dbContextOptions = new DbContextOptionsBuilder<GMPayContext>()
            //    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            //    .Options;

            //var dbContext = new GMPayContext(dbContextOptions); 

            //var controller = new MerchantController(merchantServiceMock.Object, dbContext);
            //var createMerchantDto = new CreateMerchantDto
            //{
            //    BusinessID = "uniqueBusinessID",
            //};

            //merchantServiceMock
            //    .Setup(service => service.CreateMerchantRecord(It.IsAny<CreateMerchantDto>()))
            //    .ReturnsAsync(new BaseResponse { IsSuccess = true, Message = "merchant created!" });

            //var result = await controller.CreateMerchant(createMerchantDto);

            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            //var okResult = (OkObjectResult)result;
            //Assert.IsNotNull(okResult.Value);
            //Assert.AreEqual("merchant created!", okResult.Value.ToString());

        }
    }
}