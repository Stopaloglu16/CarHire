using Domain.Common.Mappings;

namespace Domain.Entities.CarHireAggregate.EndPoints
{
    public class CarHireReturnRequest : IMapFrom<CarHireObj>
    {

        public CarHireReturnRequest()
        {
        }

        public CarHireReturnRequest(int _Id, bool _ReturnConfirmed, int _ReturnMileage)
        {
            Id = _Id;
            ReturnConfirmed = _ReturnConfirmed;
            ReturnMileage = _ReturnMileage;
        }


        public int Id { get; set; }
        public bool ReturnConfirmed { get; set; }
        public int ReturnMileage { get; set; }

    }
}
