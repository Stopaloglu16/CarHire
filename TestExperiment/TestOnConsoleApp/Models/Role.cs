using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleRoleGroups = new HashSet<RoleRoleGroup>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string RoleName { get; set; } = null!;
        public int RoleTypeId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string RoleDisplayName { get; set; } = null!;
        public int SystemFeatureId { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RoleRoleGroup> RoleRoleGroups { get; set; }

        [ForeignKey("RolesId")]
        [InverseProperty("Roles")]
        public virtual ICollection<User> Users { get; set; }
    }
}
