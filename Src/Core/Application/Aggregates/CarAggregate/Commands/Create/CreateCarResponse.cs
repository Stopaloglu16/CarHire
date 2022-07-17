using Domain.Common;

namespace Application.Aggregates.CarAggregate.Commands.Create
{
    public class CreateCarResponse
    {
        public CreateCarResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }


}
