using Domain.Common.Mappings;

namespace Domain.Entities.CarHireAggregate.EndPoints
{
    public class CarHireCreateRequest : IMapFrom<CarHireObj>
    {

        public CarHireCreateRequest()
        {
        }

        public CarHireCreateRequest(int _Id, int _CarId, int _PickUpBranchId, DateTime _PickUpDate, DateTime _PickUpDateTime,
                                    bool _PickUpConfirmed, int _ReturnBranchId, DateTime _ReturnDate, DateTime _ReturnDateTime,
                                    bool _ReturnConfirmed, int _ReturnMileage, decimal _BookingCost)
        {
            Id = _Id;
            CarId = _CarId;
            PickUpBranchId = _PickUpBranchId;
            PickUpDate = _PickUpDate;
            PickUpDateTime = _PickUpDateTime;
            PickUpConfirmed = _PickUpConfirmed;
            ReturnBranchId = _ReturnBranchId;
            ReturnDate = _ReturnDate;
            ReturnConfirmed = _ReturnConfirmed;
            ReturnMileage = _ReturnMileage;
        }


        public int Id { get; set; }
        public int CarId { get; set; }

        public int UserId { get; set; }

        public int PickUpBranchId { get; set; }

        public DateTime PickUpDate { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public bool PickUpConfirmed { get; set; }

        public int ReturnBranchId { get; set; }

        public DateTime ReturnDate { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public bool ReturnConfirmed { get; set; }

        public int ReturnMileage { get; set; }
        public decimal BookingCost { get; set; }

    }
}
