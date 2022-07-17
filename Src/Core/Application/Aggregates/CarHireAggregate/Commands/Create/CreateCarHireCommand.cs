using Application.Common.Interfaces;
using Application.Repositories;
using Domain.Entities.CarHireAggregate;
using MediatR;

namespace Application.Aggregates.CarHireAggregate.Commands.Create
{
    public class CreateCarHireCommand : IRequest<int>
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
        private readonly ICarHireRepository _repo;

        public CreateCarBrandCommandHandler(IApplicationDbContext context, ICarHireRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<int> Handle(CreateCarHireCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if( await _repo.CheckCarAvabilityById(request.CarId))
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
                else
                {

                    return 0;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        //public async Task<bool> CheckAvailability(int _carId)
        //{

        //    var myCar = await _context.Cars.FindAsync(_carId);

        //    //myCar.BranchId

        //    //var careHireList = await _context.CarHires
        //    //                                  .Where(cc => cc.CarId == _carId && cc. )
        //    //                                  .ToList();

        //    var careHireList = await _context.CarHires.FromSqlRaw("Select * FROM [Portalnow].[dbo].[PostcodeGroups] " +
        //   "WHERE Id IN(SELECT[PostcodeGroupId]" +
        //   "FROM[Portalnow].[dbo].[CompanyZonePostcodes] " +
        //    "WHERE[PostcodeId] = ( " +
        //             "SELECT [Id] FROM[Portalnow].[dbo].[Postcodes] " +
        //             "WHERE IsDeleted = 0 AND PostcodeText = '" + _carId + "') ) ").ToListAsync();



        //    return true;

        //}

    }





}
