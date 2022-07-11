using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;

namespace CarHire.Services.Branchs
{
    public interface IBranchService
    {
        Task<BranchDto> GetBranchesById(int Id);

        Task<IEnumerable<BranchDto>> GetBranches();

        Task<CreateBranchResponse> Add(CreateBranchRequest branch);
    }
}
