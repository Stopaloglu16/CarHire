using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using Application.IntegrationTests.TestData;
using CarHire.Services.Branchs;
using CarHire.Services.CarBrands;
using CarHire.Services.CarModelService;
using CarHire.Services.Cars;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using Infrastructure.Repositories.CarBrandRepos;
using Infrastructure.Repositories.CarModelRepos;
using Infrastructure.Repositories.CarRepos;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class CarServiceTests : TestBase
    {

        public CarServiceTests()
        {
            UseSqlite();
        }


        private CarDto carDto;
        private CreateCarRequest createCarRequest;
        private CarData carData;
        private CarBrandData carBrandData;
        private CarModelData carModelData;
        private BranchData branchData;


        [SetUp]
        public void SetUp()
        {
            carData = new CarData();
            carModelData = new CarModelData();
            carBrandData = new CarBrandData();
            branchData = new BranchData();
        }



        public async Task CreateCarModel(ApplicationDbContext context, bool branchPrepare = true)
        {

            #region CarBrand
            var myCarBrandRepository = new CarBrandRepository(context);
            var myCarBrandService = new CarBrandService(myCarBrandRepository);

            var myCarBrancdList = carBrandData.CreateCarBrandData().ToList();

            for (int i = 0; i < myCarBrancdList.Count; i++)
            {
                await myCarBrandService.Add(myCarBrancdList[i]);
            }
            #endregion


            #region CarModel
            var myCarModelRepository = new CarModelRepository(context);
            var myCarModelService = new CarModelService(myCarModelRepository);

            var myCarModelList = carModelData.CreateCarModelData().ToList();

            for (int i = 0; i < myCarModelList.Count; i++)
            {
                await myCarModelService.Add(myCarModelList[i]);
            }
            #endregion

            #region Branch
            if (branchPrepare)
            {
                var myBranchRepository = new BranchRepository(context);
                var myAddressRepository = new AddressRepository(context);

                var myBranchService = new BranchService(myBranchRepository, myAddressRepository);

                var myBranchList = branchData.CreateBranchData().ToList();

                for (int i = 0; i < myBranchList.Count; i++)
                {
                    await myBranchService.Add(myBranchList[i]);
                }
            }
            #endregion

        }


        [Test]
        public async Task ShouldBeAbleToAddWithoutBranchAndGetEntity()
        {
            //Preapare
            using var context = await GetDbContext();

            await CreateCarModel(context, false);

            var myCarRepository = new CarRepository(context);
            var myCarService = new CarService(myCarRepository);

            carData = new CarData(false);

            var myList2 = carData.CreateCarDataList().ToList();

            // Execute
            var myReturn = await myCarService.Add(myList2[0]);

            var data = await myCarService.GetCarDisplayById(myReturn.Id);

            // Assert
            Assert.AreEqual(myList2[0].NumberPlates, data.NumberPlates);

        }



        [Test]
        public async Task ShouldBeAbleToAddWithBranchAndGetEntity()
        {
            //Preapare
            using var context = await GetDbContext();

            await CreateCarModel(context);

            var myCarRepository = new CarRepository(context);
            var myCarService = new CarService(myCarRepository);

            var myList2 = carData.CreateCarDataList().ToList();

            // Execute
            var myReturn = await myCarService.Add(myList2[0]);

            var data = await myCarService.GetCarDisplayById(myReturn.Id);

            // Assert
            Assert.AreEqual(myList2[0].NumberPlates, data.NumberPlates);
        }

        [TestCase(1)]
        public async Task ShouldBeAbleToCreateCarThenMapbranch(int branchId)
        {
            //Preapare
            using var context = await GetDbContext();

            await CreateCarModel(context);

            var myCarRepository = new CarRepository(context);
            var myCarService = new CarService(myCarRepository);

            var myCar = carData.CreateOneCarNoBranch();

            // Execute
            var myReturn = await myCarService.Add(myCar);

            var myCarData = await myCarService.GetCarDisplayById(myReturn.Id);

            Assert.IsEmpty(myCarData.BranchName);

            UpdateCarRequest updateCarRequest = new UpdateCarRequest(myCarData.Id,
                                                                      myCarData.NumberPlates,
                                                                      branchId,
                                                                      myCarData.CarModelId,
                                                                      (Gearbox)myCarData.GearboxId,
                                                                      myCarData.Mileage,
                                                                      myCarData.Costperday);

            var updateCarResponse = await myCarService.UpdateAsync(updateCarRequest);

            // Assert
            if (updateCarResponse.basicErrorHandler.HasError)
            { 
                Assert.Fail(updateCarResponse.basicErrorHandler.ErrorMessage);
            }
            else
            {
                var myCarData1 = await myCarService.GetCarDisplayById(myReturn.Id);

                Assert.AreEqual(branchId, myCarData1.BranchId);
            }
        }



        [TearDown]
        public void Cleanup()
        {
            carData = null;
            carModelData = null;
            carBrandData = null;
            branchData = null;
        }

    }
}
