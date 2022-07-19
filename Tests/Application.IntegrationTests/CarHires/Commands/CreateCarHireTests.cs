using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IntegrationTests.CarHires.Commands
{

    public class CreateCarHireTests : TestBase
    {

        private readonly CreateCarBrandCommandHandler _handler;
        private readonly Mock<ICarHireRepository> _repo;
        private readonly ApplicationDbContext _DbContext;


        public CreateCarHireTests()
        {
            // using var context = await GetDbContext();
            //_repo = repo;    

            _repo = MockCarHireRepository.GetCarHireRepository();


            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      .UseInMemoryDatabase(databaseName: "TestCatalog")
                                      .Options;


            _DbContext = new ApplicationDbContext(dbOptions, null);

            //_repo = Mock<ICarHireRepository>();
            _handler = new CreateCarBrandCommandHandler(_DbContext, _repo.Object);

        }

        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public async Task ShouldCreateCarHireList()
        {
            
            //using var context = await GetDbContext();
            //var mybranc = new BranchRepository(context);

            //_handler = new CreateCarBrandCommandHandler(context, _repo);


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
