using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateAdminUserRequest : CreateUserRequest
    {


        [Required]
        public int RoleGroupId { get; set; }


    }
}
