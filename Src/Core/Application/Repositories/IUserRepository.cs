using Application.Aggregates.UserAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.UserAggregate;

namespace Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int Id);

    }

}
