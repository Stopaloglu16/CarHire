using Application.Aggregates.CarModelAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarModelAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CarModelRepos
{

    public class CarModelRepository : EfCoreRepository<CarModel>, ICarModelRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarModelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarModelDto> GetCarModelById(int Id)
        {
            var carModel = await GetByIdAsync(Id);

            if (carModel == null) return null;

            return new CarModelDto()
            {
                Id = carModel.Id,
                Name = carModel.Name,
                CarPhoto = carModel.CarPhoto,
                CarPhotoLenght = carModel.CarPhotoLenght,
                SeatNumber = carModel.SeatNumber
            };
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModels()
        {
            return await GetListByBool(true).Select(ss => new CarModelDto
            {
                Id = ss.Id,
                Name = ss.Name,
                CarPhoto = ss.CarPhoto,
                CarPhotoLenght = ss.CarPhotoLenght,
                SeatNumber = ss.SeatNumber
            }).ToListAsync();
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int BrandId)
        {
            return await GetListByBool(true).Where(tt => tt.CarBrandId == BrandId).Select(ss => new CarModelDto
            {
                Id = ss.Id,
                Name = ss.Name,
                CarPhoto = ss.CarPhoto,
                CarPhotoLenght = ss.CarPhotoLenght,
                SeatNumber = ss.SeatNumber
            }).ToListAsync();
        }
    }

}
