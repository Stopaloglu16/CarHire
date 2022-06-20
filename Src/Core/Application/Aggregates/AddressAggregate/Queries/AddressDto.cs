using Domain.Common.Mappings;
using Domain.Entities.AddressAggregate;

namespace Application.Aggregates.AddressAggregate.Queries
{
    public class AddressDto : IMapFrom<Address>
    {
        public string? Address1 { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }

    }
}
