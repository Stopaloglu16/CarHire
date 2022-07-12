using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.CarExtraAggregate;

namespace Application.Repositories
{

    public interface ICarExtraRepository : IRepository<CarExtra>
    {
        Task<IEnumerable<CarExtraDto>> GetCarExtras();

        Task<CarExtraDto> GetCarExtraById(int Id);

    }

}
