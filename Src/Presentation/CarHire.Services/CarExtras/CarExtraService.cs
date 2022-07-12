using Application.Aggregates.CarExtraAggregate.EndPoints;
using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarExtraAggregate;
using Domain.Entities.CarExtraAggregate.EndPoints;

namespace CarHire.Services.CarExtras
{
    public class CarExtraService : ICarExtraService
    {

        private readonly ICarExtraRepository _carExtraRepository;

        public CarExtraService(ICarExtraRepository carExtraRepository)
        {
            _carExtraRepository = carExtraRepository;
        }

        public async Task<CreateCarExtraResponse> Add(CreateCarExtraRequest carExtra)
        {
            var myReturn = await _carExtraRepository.AddAsync(new CarExtra() { Name = carExtra.Name });

            if (myReturn == null) return new CreateCarExtraResponse(0, new Domain.Common.BasicErrorHandler("SystemIssue"));

            return new CreateCarExtraResponse(myReturn.Id, new Domain.Common.BasicErrorHandler());
        }

        public async Task<CarExtraDto> GetCarBrandById(int Id)
        {
            return await _carExtraRepository.GetCarExtraById(Id);
        }

        public Task<IEnumerable<CarExtraDto>> GetCarBrands()
        {
            throw new NotImplementedException();
        }
    }


}
