using Application.Aggregates.AddressAggregate.Queries;
using Domain.Common.Mappings;
using Domain.Entities.BranchAggregate;

namespace Application.Aggregates.BranchAggregate.Queries
{
    public class BranchDto : IMapFrom<Branch>
    {

        public int Id { get; set; }
        public string? BranchName { get; set; }

        public AddressDto? Address { get; set; } = new AddressDto();

    }
}
