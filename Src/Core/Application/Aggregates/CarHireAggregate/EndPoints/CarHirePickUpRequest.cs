using Domain.Common.Mappings;

namespace Domain.Entities.CarHireAggregate.EndPoints
{
    public class CarHirePickUpRequest : IMapFrom<CarHire>
    {

        public CarHirePickUpRequest()
        {
        }

        public CarHirePickUpRequest(int _Id, bool _PickUpConfirmed)
        {
            Id = _Id;
            PickUpConfirmed = _PickUpConfirmed;
        }


        public int Id { get; set; }
        public bool PickUpConfirmed { get; set; }

    }
}
