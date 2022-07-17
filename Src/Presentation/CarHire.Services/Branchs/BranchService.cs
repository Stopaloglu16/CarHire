using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;

namespace CarHire.Services.Branchs
{
    public class BranchService : IBranchService
    {

        private readonly IBranchRepository _branchRepository;
        private readonly IAddressRepository _addressRepository;

        public BranchService(IBranchRepository branchRepository, IAddressRepository addressRepository)
        {
            _branchRepository = branchRepository;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<BranchDto>> GetBranches()
        {
            return await _branchRepository.GetBranches();
        }


        public async Task<CreateBranchResponse> Add(CreateBranchRequest branch)
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
                    var myBranch = await _branchRepository.AddAsync(new Branch()
                    {

                        BranchName = branch.BranchName,
                        AddressId = myRtn.Id
                    });

                    return new CreateBranchResponse(myBranch.Id, new BasicErrorHandler("Address not created"));
                }

                return new CreateBranchResponse(-1, new BasicErrorHandler("Address not created"));
            }
            catch (Exception ex)
            {
                return new CreateBranchResponse(-1, new BasicErrorHandler("Address not created"));
            }
        }

        public async Task<BranchDto> GetBranchesById(int Id)
        {
            return await _branchRepository.GetBranchesById(Id);
        }


        public async Task<Branch> DeleteBranchById(int Id)
        {
            return await _branchRepository.DeleteAsync(Id);
        }


    }
}
