using Application.Aggregates.CarAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.CarAggregate;

namespace Application.Repositories
{

    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<CarDto>> GetCars();
    }

}
