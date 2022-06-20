using Domain.Common;

namespace Domain.Entities.UserAuthAggregate.Register
{
    public class UserRegisterResponse
    {
        public BasicErrorHandler basicErrorHandler { get; set; }

        public UserRegisterResponse()
        {
            basicErrorHandler = new BasicErrorHandler();
        }
    }
}
