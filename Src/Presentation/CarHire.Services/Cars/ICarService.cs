using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Queries;

namespace CarHire.Services.Cars
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetCars();

        Task<CarDto> GetCarById(int Id);

        Task<IEnumerable<CarDto>> GetCarsByBranchId(int BranchId);

        Task<CreateCarResponse> Add(CreateCarRequest carModel);

    }
}
