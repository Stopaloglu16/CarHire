using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.CarHireAggregate;

namespace Application.IntegrationTests.CarHires
{

    public static class MockCarHireRepository
    {
        public static Mock<ICarHireRepository> GetCarHireRepository()
        {
            var leaveTypes = new List<CarHireObj>
            {
                new CarHireObj(){

                   CarId = 1,
                    ReturnBranchId = 1,
                    UserId = 1,
                     ReturnDate = DateTime.Now,
                     ReturnDateTime = DateTime.Now,
                    PickUpBranchId = 1,
                     PickUpDate =  DateTime.Now,
                     PickUpDateTime = DateTime.Now,
                      ReturnMileage = 0,
                      BookingCost = 12
                }
            
            };

        var mockRepo = new Mock<ICarHireRepository>();

        //mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(r => r.AddAsync(It.IsAny<CarHireObj>())).ReturnsAsync((CarHireObj leaveType) =>
            {
            leaveTypes.Add(leaveType);
            return leaveType;
        });

            return mockRepo;

        }
}
}
