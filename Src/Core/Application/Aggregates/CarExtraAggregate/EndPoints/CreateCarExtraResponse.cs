using Domain.Common;

namespace Application.Aggregates.CarExtraAggregate.EndPoints
{

    public class CreateCarExtraResponse
    {
        public CreateCarExtraResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }
}
