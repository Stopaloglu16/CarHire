using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarExtraAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CarExtraRepos
{
  
    public class CarExtraRepository : EfCoreRepository<CarExtra>, ICarExtraRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarExtraRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarExtraDto> GetCarExtraById(int Id)
        {
            var carExtra = await GetByIdAsync(Id);

            if (carExtra == null) return null;

            return new CarExtraDto() { Id = carExtra.Id, Name = carExtra.Name, Cost = carExtra.Cost };
        }

        public async Task<IEnumerable<CarExtraDto>> GetCarExtras()
        {
            return await GetListByBool(true).Select(ss => new CarExtraDto
            {
                Id = ss.Id,
                Name = ss.Name,
                Cost = ss.Cost

            }).ToListAsync();
        }


    }


}
