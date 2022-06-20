using Application.Repositories;
using Domain.Entities.AddressAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;

namespace Infrastructure.Repositories.AddressRepos
{
    public class AddressRepository : EfCoreRepository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
