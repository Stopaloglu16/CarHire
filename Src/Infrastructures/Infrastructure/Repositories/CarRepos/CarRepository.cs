using Application.Aggregates.CarAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CarRepos
{

    public class CarRepository : EfCoreRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<CarDto>> GetCars()
        {

            return await GetListByBool(true).Include(bb => bb.CarModel)
                                                  .ThenInclude(cc => cc.CarBrand)
                                                    .Include(bb => bb.Branch)
                                                    .Include(bb => bb.Gearbox)
                                                    .Select(ss => new CarDto
                                                    {
                                                        Id = ss.Id,
                                                        NumberPlates = ss.NumberPlates,
                                                        BranchName = ss.Branch.BranchName,
                                                        CarModelName = ss.CarModel.Name,
                                                        GearboxName = ss.Gearbox.ToString(),
                                                        Mileage = ss.Mileage,
                                                        Costperday = ss.Costperday

                                                    }).ToListAsync();

        }


    }
}
