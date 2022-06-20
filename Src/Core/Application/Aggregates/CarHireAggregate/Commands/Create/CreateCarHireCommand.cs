using Application.Common.Interfaces;
using Domain.Entities.CarHireAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aggregates.CarHireAggregate.Commands.Create
{
    public class CreateCarHireCommand: IRequest<int>
    {
        public CreateCarHireCommand(int carId, int userId, int pickUpBranchId, DateTime pickUpDate, DateTime pickUpDateTime, int returnBranchId, DateTime returnDate, DateTime returnDateTime, int returnMileage, decimal bookingCost)
        {
            CarId = carId;
            UserId = userId;
            PickUpBranchId = pickUpBranchId;
            PickUpDate = pickUpDate;
            PickUpDateTime = pickUpDateTime;
            ReturnBranchId = returnBranchId;
            ReturnDate = returnDate;
            ReturnDateTime = returnDateTime;
            ReturnMileage = returnMileage;
            BookingCost = bookingCost;
        }


        public int CarId { get; set; }
        public int UserId { get; set; }
        public int PickUpBranchId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public int ReturnBranchId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int ReturnMileage { get; set; }
        public decimal BookingCost { get; set; }

    }




    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarHireCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCarBrandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCarHireCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new CarHire();

                entity.CarId = request.CarId;
                entity.UserId = request.UserId;
                entity.BookingCost = request.BookingCost;

                entity.PickUpBranchId = request.PickUpBranchId;
                entity.PickUpDate = request.PickUpDate;
                entity.PickUpDateTime = request.PickUpDate;

                entity.ReturnBranchId = request.ReturnBranchId;
                entity.ReturnDate = request.ReturnDate;
                entity.ReturnDateTime = request.ReturnDateTime;

                _context.CarHires.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        //public async Task<bool> CheckAvailability(int _carId)
        //{

        //    var isavailable = await _context.CarHires
        //                                      .Where(cc => cc.CarId == _carId && cc. )
        //                                      .ToList();

        //    return true;

        //}

    }


 


}
