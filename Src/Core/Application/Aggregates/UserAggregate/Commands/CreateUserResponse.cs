using Domain.Common;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateUserResponse
    {
        public CreateUserResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();


    }
}
