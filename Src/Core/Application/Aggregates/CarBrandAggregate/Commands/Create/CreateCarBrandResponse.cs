using Domain.Common;

namespace Application.Aggregates.CarBrandAggregate.Commands.Create
{

    public class CreateCarBrandResponse
    {
        public CreateCarBrandResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }
}
