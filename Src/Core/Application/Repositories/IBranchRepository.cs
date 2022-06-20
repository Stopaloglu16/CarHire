using Application.Aggregates.BranchAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.BranchAggregate;

namespace Application.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<BranchDto>> GetBranches();

    }

}
