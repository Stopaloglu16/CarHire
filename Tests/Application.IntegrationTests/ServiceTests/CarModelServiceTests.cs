using Application.IntegrationTests.TestData;
using CarHire.Services.CarBrands;
using CarHire.Services.CarModelService;
using Infrastructure.Data;
using Infrastructure.Repositories.CarBrandRepos;
using Infrastructure.Repositories.CarModelRepos;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class CarModelServiceTests : TestBase
    {
        public CarModelServiceTests()
        {
            UseSqlite();
        }


        private string myCarBrand;
        private CarModelData carModelData;
        private CarBrandData carBrandData;

        [SetUp]
        public void SetUp()
        {
            myCarBrand = "5 Series";
            carModelData = new CarModelData();
            carBrandData = new CarBrandData();
        }


        public async Task CreateCarBrand(ApplicationDbContext context)
        {
            var myCarBrandRepository = new CarBrandRepository(context);
            var myCarBrandService = new CarBrandService(myCarBrandRepository);

            // Prepare
            var myList = carBrandData.CreateCarBrandData().ToList();

            // Execute
            for (int i = 0; i < myList.Count; i++)
            {
                await myCarBrandService.Add(myList[i]);
            }
        }
            

        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            using var context = await GetDbContext();

           
            await CreateCarBrand(context);

            var myCarModelRepository = new CarModelRepository(context);
            var myCarModelService = new CarModelService(myCarModelRepository);

            // Prepare
            var myList1 = carModelData.CreateCarModelData().ToList();

            // Execute
            var myReturn = await myCarModelService.Add(myList1[0]);

            var data = await myCarModelService.GetCarModelById(myReturn.Id);

            // Assert
            Assert.AreEqual(myCarBrand, data.Name);

        }


    }
}
