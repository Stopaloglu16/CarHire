using Domain.Common;
using Domain.Entities.RoleAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserAuthAggregate.Login
{

    [NotMapped]
    public class UserLogInResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public string AspId { get; set; }

        public ICollection<Role> myRoles { get; set; } = new List<Role>();

        public BasicErrorHandler BasicErrorHandler { get; set; } = new BasicErrorHandler();


    }
}
