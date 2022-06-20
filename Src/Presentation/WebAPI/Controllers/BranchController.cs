using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BranchController : ApiController
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IAddressRepository _addressRepository;

        public BranchController(IBranchRepository branchRepository, IAddressRepository addressRepository)
        {
            _branchRepository = branchRepository;
            _addressRepository = addressRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<BranchDto>> Get()
        {
            return await _branchRepository.GetBranches();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBranchRequest branch)
        {
            try
            {

                var myRtn = await _addressRepository.AddAsync(new Address()
                {
                    Id = 0,
                    Address1 = branch.Address.Address1,
                    City = branch.Address.City,
                    Postcode = branch.Address.Postcode,
                    addressType = Domain.Enums.AddressType.BranchAddress
                });


                if (myRtn.Id > 0)
                {
                    var myBranch = await _branchRepository.AddAsync( new Branch() {
                     
                        BranchName = branch.BranchName,
                        AddressId = myRtn.Id
                    });   

                    return  Ok(myBranch.Id);
                }

                return BadRequest(-1);
            }
            catch (Exception ex)
            {
                await Task.Delay(500);
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
