using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateAdminUserRequest
    {

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; }

        [Required]
        public int UserTypeId { get; set; }


        [Required]
        public int RoleGroupId { get; set; }

        
        public int? BranchId { get; set; }


    }
}
