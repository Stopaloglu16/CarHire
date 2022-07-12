using Domain.Common;

namespace Application.Aggregates.CarModelAggregate.Commands.Create
{

    public class CreateCarModelResponse
    {
        public CreateCarModelResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }

}
