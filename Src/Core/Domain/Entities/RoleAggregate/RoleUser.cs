using Domain.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.RoleAggregate
{
    public partial class RoleUser
    {
        [Key]
        public int RolesId { get; set; }
        [Key]
        public int UsersId { get; set; }

        [ForeignKey(nameof(RolesId))]
        [InverseProperty(nameof(Role.RoleUsers))]
        public virtual Role Roles { get; set; }
        [ForeignKey(nameof(UsersId))]
        [InverseProperty(nameof(User.RoleUsers))]
        public virtual User Users { get; set; }
    }
}
