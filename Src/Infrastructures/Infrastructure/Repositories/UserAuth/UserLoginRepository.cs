using Application.Repositories;
using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserAuth
{
    public class UserLoginRepository : IUserLoginRepository
    {

        private readonly ApplicationDbContext _DbContext;

        public UserLoginRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<UserLogInResponse> GetUserDetailsAsync(string AspId)
        {
            try
            {
                var myuser = await _DbContext.Users.Where(uu => uu.AspId == AspId)
                                                          .Include(uu => uu.RoleUsers)
                                                          .FirstOrDefaultAsync();

                var myRoles = _DbContext.Roles.ToList();

                //List<Role> roles = new List<Role>();

                //foreach (Role myitem in myRoles)
                //{
                //    if (myuser.RoleUsers.Any(rr => rr.RolesId == myitem.Id))
                //    {
                //        roles.Add(myitem);
                //    }
                //}


                UserLogInResponse userLogInResponse = new UserLogInResponse
                {
                    AspId = AspId,
                    UserName = myuser.UserName,
                    AccessToken = "",
                    RefreshToken = "",
                    UserEmail = myuser.UserEmail,
                    Id = myuser.Id
                    //myRoles = roles,
                    //pnErrorHandler = new PnErrorHandler()
                };


                return userLogInResponse;

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SaveRefreshTokenAsync(RefreshToken refreshToken, int _UserId)
        {
            _DbContext.RefreshTokens.Add(
                       new RefreshToken
                       {
                           UserId = _UserId,
                           Token = refreshToken.Token,
                           ExpiryDate = refreshToken.ExpiryDate
                       });

            await _DbContext.SaveChangesAsync();

            return true;
        }

    }
}
