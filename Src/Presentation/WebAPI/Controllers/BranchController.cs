using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using CarHire.Services.Branchs;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BranchController : ApiController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }


        [HttpGet]
        public async Task<IEnumerable<BranchDto>> Get()
        {
            return await _branchService.GetBranches();
        }

        [HttpPost]
        public async Task<ActionResult<CreateBranchResponse>> Create(CreateBranchRequest branch)
        {
            try
            {
                return await _branchService.Add(branch); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, UpdateCarBrandCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

    }


}
