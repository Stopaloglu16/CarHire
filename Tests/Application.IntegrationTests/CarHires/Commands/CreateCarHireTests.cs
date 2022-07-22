using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.IntegrationTests.TestData;
using Application.Repositories;
using CarHire.Services.Branchs;
using CarHire.Services.CarBrands;
using CarHire.Services.CarModelService;
using Infrastructure.Data;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using Infrastructure.Repositories.CarBrandRepos;
using Infrastructure.Repositories.CarModelRepos;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IntegrationTests.CarHires.Commands
{

    public class CreateCarHireTests : TestBase
    {

        private readonly CreateCarBrandCommandHandler _handler;
        private readonly Mock<ICarHireRepository> _repo;
        private readonly ApplicationDbContext _DbContext;

        private CarDto carDto;
        private CreateCarRequest createCarRequest;
        private CarData carData;
        private CarBrandData carBrandData;
        private CarModelData carModelData;
        private BranchData branchData;


        public CreateCarHireTests()
        {

         

            _repo = MockCarHireRepository.GetCarHireRepository();

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseSqlite("DataSource=:memory:", x => { })
                                      .Options;

            _DbContext = new ApplicationDbContext(dbOptions, null);

            // SQLite needs to open connection to the DB.
            // Not required for in-memory-database and MS SQL.
            _DbContext.Database.OpenConnectionAsync();

            _DbContext.Database.EnsureCreatedAsync();

            //_repo = Mock<ICarHireRepository>();
            _handler = new CreateCarBrandCommandHandler(_DbContext, _repo.Object);


        }

        public async Task ExecuteAsync()
        {
            carData = new CarData();
            carModelData = new CarModelData();
            carBrandData = new CarBrandData();
            branchData = new BranchData();

            #region CarBrand
            var myCarBrandRepository = new CarBrandRepository(_DbContext);
            var myCarBrandService = new CarBrandService(myCarBrandRepository);

            var myCarBrancdList = carBrandData.CreateCarBrandData().ToList();

            for (int i = 0; i < myCarBrancdList.Count; i++)
            {
                await myCarBrandService.Add(myCarBrancdList[i]);
            }
            #endregion


            #region CarModel
            var myCarModelRepository = new CarModelRepository(_DbContext);
            var myCarModelService = new CarModelService(myCarModelRepository);

            var myCarModelList = carModelData.CreateCarModelData().ToList();

            for (int i = 0; i < myCarModelList.Count; i++)
            {
                await myCarModelService.Add(myCarModelList[i]);
            }
            #endregion

            #region Branch

            var myBranchRepository = new BranchRepository(_DbContext);
            var myAddressRepository = new AddressRepository(_DbContext);

            var myBranchService = new BranchService(myBranchRepository, myAddressRepository);

            var myBranchList = branchData.CreateBranchData().ToList();

            for (int i = 0; i < myBranchList.Count; i++)
            {
                await myBranchService.Add(myBranchList[i]);
            }

            #endregion

        }


        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public async Task ShouldCreateCarHireList()
        {


            await ExecuteAsync();

            var command = new CreateCarHireCommand(1,
                                                                     1,
                                                                     1,
                                                                     DateTime.Now.AddDays(1),
                                                                     DateTime.Now.AddDays(1),
                                                                     1,
                                                                     DateTime.Now.AddDays(2),
                                                                     DateTime.Now.AddDays(2),
                                                                     120,
                                                                     15);

            var result = await _handler.Handle(command, CancellationToken.None);


            //var listId = await SendAsync(command);

            var command1 = new CreateCarHireCommand(1,
                                                                 1,
                                                                 1,
                                                                 DateTime.Now.AddDays(1),
                                                                 DateTime.Now.AddDays(1),
                                                                 1,
                                                                 DateTime.Now.AddDays(2),
                                                                 DateTime.Now.AddDays(2),
                                                                 120,
                                                                 15);

            var result1 = await _handler.Handle(command1, CancellationToken.None);



            Assert.Equals(1, 0);


            //var list = await FindAsync<TodoList>(listId);

            //list.Should().NotBeNull();
            //list.Title.Should().Be(command.Title);
            //list.Created.Should().BeCloseTo(DateTime.Now, 10000);
            //list.CreatedBy.Should().Be(userId);
        }
    }




}
