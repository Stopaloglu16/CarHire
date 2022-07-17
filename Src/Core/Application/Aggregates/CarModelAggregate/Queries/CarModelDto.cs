using Domain.Common.Mappings;
using Domain.Entities.CarModelAggregate;

namespace Application.Aggregates.CarModelAggregate.Queries
{
    public class CarModelDto : IMapFrom<CarModel>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? CarPhoto { get; set; }
        public int? CarPhotoLenght { get; set; }
        public int SeatNumber { get; set; }
        public int CarBrandId { get; set; }

    }
}
