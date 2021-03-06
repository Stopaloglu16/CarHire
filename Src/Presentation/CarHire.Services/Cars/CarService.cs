using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.CarAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Services.Cars
{
  
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public async Task<CreateCarResponse> Add(CreateCarRequest car)
        {
            var myReturn = await _carRepository.AddAsync(new Car()
            {
                 NumberPlates = car.NumberPlates,
                 BranchId = car.BranchId,
                 CarModelId = car.CarModelId,
                 Gearbox = car.Gearbox,
                 Mileage = car.Mileage,
                 Costperday = car.Costperday
            });

            if (myReturn == null) return new CreateCarResponse(0, new BasicErrorHandler("SystemIssue"));

            return new CreateCarResponse(myReturn.Id, new BasicErrorHandler());
        }

        public async Task<CarDto> GetCarDisplayById(int Id)
        {
            return await _carRepository.GetCarById(Id);
        }

        public Task<IEnumerable<CarDto>> GetCars()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarDto>> GetCarsByBranchId(int BranchId)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateCarResponse> UpdateAsync(UpdateCarRequest updateCarRequest)
        {
            try
            {
                var myCurrenctValue = await _carRepository.GetByIdAsync(updateCarRequest.Id);

                myCurrenctValue.BranchId = updateCarRequest.BranchId;
                myCurrenctValue.CarModelId = updateCarRequest.CarModelId;
                myCurrenctValue.Gearbox = updateCarRequest.Gearbox;
                myCurrenctValue.Mileage = updateCarRequest.Mileage;

                await _carRepository.UpdateAsync(myCurrenctValue);

                return new UpdateCarResponse(updateCarRequest.Id, new BasicErrorHandler());
            }
            catch (Exception ex)
            {
                return new UpdateCarResponse(updateCarRequest.Id, new BasicErrorHandler( ex.Message));
            }

        }


    }
}
