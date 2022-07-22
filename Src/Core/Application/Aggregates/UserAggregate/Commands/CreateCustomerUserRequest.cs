using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateCustomerUserRequest : CreateUserRequest
    {


        [Required]
        public int RoleGroupId { get; set; }


    }
}
