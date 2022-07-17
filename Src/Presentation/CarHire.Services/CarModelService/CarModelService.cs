using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarModelAggregate;

namespace CarHire.Services.CarModelService
{
    public class CarModelService : ICarModelService
    {

        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public async Task<CreateCarModelResponse> Add(CreateCarModelRequest carModel)
        {
            var myReturn = await _carModelRepository.AddAsync(new CarModel()
            {
                Name = carModel.Name,
                CarBrandId = carModel.CarBrandId,
                CarPhoto = carModel.CarPhoto,
                CarPhotoLenght = carModel.CarPhotoLenght,
                SeatNumber = carModel.SeatNumber
            });

            if (myReturn == null) return new CreateCarModelResponse(0, new Domain.Common.BasicErrorHandler("SystemIssue"));

            return new CreateCarModelResponse(myReturn.Id, new Domain.Common.BasicErrorHandler());
        }

        public async Task<CarModelDto> GetCarModelById(int Id)
        {
            return await _carModelRepository.GetCarModelById(Id);
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModels()
        {
            return await _carModelRepository.GetCarModels();
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int brandId)
        {
            return await _carModelRepository.GetCarModelsByBrandId(brandId);
        }

    }
}
