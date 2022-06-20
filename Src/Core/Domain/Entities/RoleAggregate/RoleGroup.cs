using Domain.Common;
using Domain.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.RoleAggregate
{
    public class RoleGroup : BaseEntity<int>
    {
        public RoleGroup()
        {
            RoleGroupName = "";
            IsDeleted = 0;
        }


        [Required]
        [Column(TypeName = "varchar(150)")]
        public string RoleGroupName { get; set; }

        public int CompanyId { get; set; }
        public int UserTypeID { get; set; }




        [InverseProperty(nameof(User.RoleGroup))]
        public virtual ICollection<User> Users { get; set; }


        public ICollection<Role> Roles { get; set; }


        [InverseProperty(nameof(RoleRoleGroup.RoleGroup))]
        public virtual ICollection<RoleRoleGroup> RoleRoleGroups { get; set; }



    }
}
