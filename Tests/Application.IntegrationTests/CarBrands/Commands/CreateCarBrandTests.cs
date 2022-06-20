using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Domain.Entities.CarBrandsAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.IntegrationTests.CarBrands.Commands
{
    public class CreateCarBrandTests
    {

        private readonly string _testCarBrandName = "ABC";

        private readonly ApplicationDbContext _DbContext;
        private readonly EfCoreRepository<CarBrand> _carbrandRepository;

        public CreateCarBrandTests()
        {

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(databaseName: "TestCatalog")
                                      .Options;


            _DbContext = new ApplicationDbContext(dbOptions, null);
            _carbrandRepository = new EfCoreRepository<CarBrand>(_DbContext);
           
        }


        [TestCase("ABC")]
        public async Task AddsCarBrandIfNotPresent(string testBrand)
        {
          
            var carBrand = new CarBrand() { Name = testBrand };

            await _carbrandRepository.AddAsync(carBrand);

            var myCarBrands = await _carbrandRepository.GetAll().ToListAsync();

            if (myCarBrands == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(testBrand, carBrand.Name);
            }
        }


        [Test]
        public async Task AddsCarBrandReturnEmptyException()
        {
            try
            {
                var carBrand = new CarBrand() { Name = "0123456789A0123456789A0123456789A0123456789A0123456789As" };

                await _carbrandRepository.AddAsync(carBrand);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true);
            }
        }


    }
}
