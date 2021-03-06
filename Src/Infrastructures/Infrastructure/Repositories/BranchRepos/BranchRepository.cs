using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Entities.BranchAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BranchRepos
{

    public class BranchRepository : EfCoreRepository<Branch>, IBranchRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BranchRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<BranchDto>> GetBranches()
        {

            return await GetListByBool(true).Include(bb => bb.Address)
                                                    .Select(ss => new BranchDto
                                                    {
                                                        Id = ss.Id,
                                                        BranchName = ss.BranchName
                                                         ,
                                                        Address = new AddressDto()
                                                        {
                                                            Address1 = ss.Address.Address1,
                                                            City = ss.Address.City,
                                                            Postcode = ss.Address.Postcode
                                                        }

                                                    }).ToListAsync();
        }

        public async Task<BranchDto> GetBranchesById(int Id)
        {
            var myBranch = await GetByIdAsync(Id);

            if (myBranch == null) return null;

            return new BranchDto() { Id = myBranch.Id, 
                                     BranchName = myBranch.BranchName, 
                                     Address = new AddressDto() {  Address1 = myBranch.Address.Address1,
                                                                   City = myBranch.Address.City,
                                                                   Postcode = myBranch.Address.Postcode} 
                                    };

        }

    }
}
