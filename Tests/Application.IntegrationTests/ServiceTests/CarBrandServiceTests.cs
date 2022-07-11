using Application.IntegrationTests.TestData;
using CarHire.Services.CarBrands;
using Infrastructure.Repositories.CarBrandRepos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class CarBrandServiceTests : TestBase
    {

        public CarBrandServiceTests()
        {
            UseSqlite();
        }

        private string? myCarBrand;
        private CarBrandData? carBrandData;
        

        [SetUp]
        public void SetUp()
        {
            myCarBrand = "BMW";
            carBrandData = new CarBrandData();
        }



        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            using var context = await GetDbContext();
            var myCarBrandRepository = new CarBrandRepository(context);

            var myCarBrandService = new CarBrandService(myCarBrandRepository);

            // Prepare
            var myList = carBrandData.CreateCarBrandData().ToList();

            // Execute
            var myReturn = await myCarBrandService.Add(myList[0]);

            var data = await myCarBrandService.GetCarBrandById(myReturn.Id);

            // Assert
            Assert.AreEqual(myCarBrand, data.Name);

        }




    }
}
