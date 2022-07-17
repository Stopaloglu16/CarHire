using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Queries;

namespace CarHire.Services.CarModelService
{

    public interface ICarModelService
    {
        Task<IEnumerable<CarModelDto>> GetCarModels();

        Task<CarModelDto> GetCarModelById(int Id);

        Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int BrandId);

        Task<CreateCarModelResponse> Add(CreateCarModelRequest carModel);

    }

}
