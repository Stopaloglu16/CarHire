using Application.Aggregates.CarModelAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.CarModelAggregate;

namespace Application.Repositories
{

    public interface ICarModelRepository : IRepository<CarModel>
    {
        Task<IEnumerable<CarModelDto>> GetCarModels();

        Task<CarModelDto> GetCarModelById(int Id);

        Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int BrandId);
    }

}
