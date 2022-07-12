using Application.Aggregates.CarExtraAggregate.Queries;
using Domain.Entities.CarExtraAggregate.EndPoints;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{
    public class CarExtraData
    {

        private readonly string[] carExtraNameArray;
        private readonly decimal[] carExtraCostArray;

        public CarExtraData()
        {
            carExtraNameArray = new string[3] { "Baby seat", "Child Seat", "Navigation" };
            carExtraCostArray = new decimal[3] { 4, 5, 2 };
        }


        public IEnumerable<CreateCarExtraRequest> CreateCarExtraData()
        {
            var myList = new List<CreateCarExtraRequest>();

            for (int i = 0; i < carExtraNameArray.Length; i++)
            {
                CreateCarExtraRequest createCarExtraRequest = new CreateCarExtraRequest();

                createCarExtraRequest.Name = carExtraNameArray[i];
                createCarExtraRequest.Cost = carExtraCostArray[i];

                myList.Add(createCarExtraRequest);
            }

            return myList;
        }


        public IEnumerable<CarExtraDto> DisplayCarExtraData()
        {

            var myList = new List<CarExtraDto>();

            for (int i = 0; i < carExtraNameArray.Length; i++)
            {
                CarExtraDto carBrandDto = new CarExtraDto();

                carBrandDto.Name = carExtraNameArray[i];
                carBrandDto.Cost = carExtraCostArray[i];

                myList.Add(carBrandDto);
            }

            return myList;
        }

    }

}
