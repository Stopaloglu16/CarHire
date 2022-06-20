using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;

namespace Application.Repositories
{
    public interface IUserLoginRepository
    {

        Task<UserLogInResponse> GetUserDetailsAsync(string AspId);

        Task<bool> SaveRefreshTokenAsync(RefreshToken refreshToken, int _UserId);
    }
}
