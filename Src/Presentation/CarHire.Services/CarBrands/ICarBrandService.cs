using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;

namespace CarHire.Services.CarBrands
{
    public interface ICarBrandService
    {
        Task<CarBrandDto> GetCarBrandById(int Id);

        Task<IEnumerable<CarBrandDto>> GetCarBrands();

        Task<CreateCarBrandResponse> Add(CreateCarBrandRequest carBrand);
    }

}
