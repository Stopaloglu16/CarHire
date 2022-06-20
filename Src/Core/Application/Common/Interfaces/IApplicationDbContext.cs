
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;
using Domain.Entities.CarAggregate;
using Domain.Entities.CarBrandsAggregate;
using Domain.Entities.CardDetailAggregate;
using Domain.Entities.CarExtraAggregate;
using Domain.Entities.CarHireAggregate;
using Domain.Entities.CarModelAggregate;
using Domain.Entities.RoleAggregate;
using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<CarHire> CarHires { get; set; }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
