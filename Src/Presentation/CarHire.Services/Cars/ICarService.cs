using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;

namespace CarHire.Services.Cars
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetCars();

        Task<CarDto> GetCarDisplayById(int Id);

        Task<IEnumerable<CarDto>> GetCarsByBranchId(int BranchId);

        Task<CreateCarResponse> Add(CreateCarRequest carModel);

        Task<UpdateCarResponse> UpdateAsync(UpdateCarRequest updateCarRequest);

    }
}
