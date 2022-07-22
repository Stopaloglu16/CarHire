using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateBrancUserRequest : CreateUserRequest
    {

     
        [Required]
        public int RoleGroupId { get; set; }

        
        public int? BranchId { get; set; }


    }
}
