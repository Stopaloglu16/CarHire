using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;

namespace Application.IntegrationTests.TestData
{
    public class UserData
    {

        public CreateAdminUserRequest CreateAdminUser()
        {
            CreateAdminUserRequest createUserRequest = new CreateAdminUserRequest();

            return createUserRequest;
        }

        public UserDto DisplayAdminUser()
        {
            UserDto userDto = new UserDto();

            return userDto;
        }

        public CreateAdminUserRequest CreateBranchUser()
        {
            CreateAdminUserRequest createUserRequest = new CreateAdminUserRequest();

            return createUserRequest;
        }

        public UserDto DisplayBranchUser()
        {
            UserDto userDto = new UserDto();

            return userDto;
        }

        public CreateAdminUserRequest CreateCustomerUser()
        {
            CreateAdminUserRequest createUserRequest = new CreateAdminUserRequest();

            return createUserRequest;
        }

        public UserDto DisplayCustomerUser()
        {
            UserDto userDto = new UserDto();

            return userDto;
        }
    }
}
