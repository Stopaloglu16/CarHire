using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Services.Branchs
{
    public interface IBranchService
    {

        Task<BranchDto> GetBranchesById(int Id);

        Task<IEnumerable<BranchDto>> GetBranches();

        Task<CreateBranchResponse> Add(CreateBranchRequest branch);


    }
}
