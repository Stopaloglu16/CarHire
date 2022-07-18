using Application.Aggregates.CarHireAggregate.Commands.Create;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.IntegrationTests.CarHires.Commands
{
    using static TestingCqrs;

    public class CreateCarHireTests : TestBaseCqrs
    {


        [Test]
        public async Task ShouldCreateCarHireList()
        {
            // var userId = await RunAsDefaultUserAsync();


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

            var listId = await SendAsync(command);


            Assert.Equals(1, listId);


            //var list = await FindAsync<TodoList>(listId);

            //list.Should().NotBeNull();
            //list.Title.Should().Be(command.Title);
            //list.Created.Should().BeCloseTo(DateTime.Now, 10000);
            //list.CreatedBy.Should().Be(userId);
        }
    }




}
