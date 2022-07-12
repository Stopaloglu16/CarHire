using Application.Aggregates.CarExtraAggregate.EndPoints;
using Application.Aggregates.CarExtraAggregate.Queries;
using Domain.Entities.CarExtraAggregate.EndPoints;

namespace CarHire.Services.CarExtras
{

    public interface ICarExtraService
    {
        Task<CarExtraDto> GetCarBrandById(int Id);

        Task<IEnumerable<CarExtraDto>> GetCarBrands();

        Task<CreateCarExtraResponse> Add(CreateCarExtraRequest carBrand);
    }


}
