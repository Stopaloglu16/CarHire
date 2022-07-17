using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Queries;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{

    public class CarModelData
    {

        private readonly List<CarModelDto> carModelDtos;

        public CarModelData()
        {
            carModelDtos = new List<CarModelDto>() {

                new CarModelDto() { Name = "5 Series", CarBrandId = 1,  SeatNumber = 5, CarPhoto = "abc123", CarPhotoLenght = 6 },
                new CarModelDto() { Name = "i3", CarBrandId = 1,  SeatNumber = 2, CarPhoto = "abc123", CarPhotoLenght = 6 },

                new CarModelDto() { Name = "Aygo", CarBrandId = 2,  SeatNumber = 2, CarPhoto = "abc123", CarPhotoLenght = 6 },
                new CarModelDto() { Name = "CHR", CarBrandId = 2,  SeatNumber = 5, CarPhoto = "abc123", CarPhotoLenght = 6 },

                new CarModelDto() { Name = "A4", CarBrandId = 3,  SeatNumber = 5, CarPhoto = "abc123", CarPhotoLenght = 6 },
                new CarModelDto() { Name = "S5", CarBrandId = 3,  SeatNumber = 5, CarPhoto = "abc123", CarPhotoLenght = 6 },

                new CarModelDto() { Name = "Astra", CarBrandId = 4,  SeatNumber = 5, CarPhoto = "abc123", CarPhotoLenght = 6 },
                new CarModelDto() { Name = "Corsa", CarBrandId = 4,  SeatNumber = 5, CarPhoto = "abc123", CarPhotoLenght = 6 }

            };
        }

        public IEnumerable<CreateCarModelRequest> CreateCarModelData()
        {
            var myList = new List<CreateCarModelRequest>();

            for (int i = 0; i < carModelDtos.Count; i++)
            {
                var createModelRequest = new CreateCarModelRequest(carModelDtos[i].Name.ToString(),
                                                                                        carModelDtos[i].CarPhoto,
                                                                                        (int)carModelDtos[i].CarPhotoLenght,
                                                                                        carModelDtos[i].SeatNumber,
                                                                                        carModelDtos[i].CarBrandId);

                myList.Add(createModelRequest);
            }

            return myList;
        }


        public CreateCarModelRequest CreateEmptyCarModelData()
        {
            var createModelRequest = new CreateCarModelRequest("",
                                                                                    "",
                                                                                    0,
                                                                                    0,
                                                                                    0);

            return createModelRequest;
        }

        public CreateCarModelRequest CreateNullCarModelData()
        {
            var createModelRequest = new CreateCarModelRequest(null,
                                                                                    null,
                                                                                    0,
                                                                                    0,
                                                                                    0);

            return createModelRequest;
        }

        public IEnumerable<CarModelDto> DisplayCarModelData()
        {
            return carModelDtos;
        }

    }
}
