using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Table("RoleGroup")]
    public partial class RoleGroup
    {
        public RoleGroup()
        {
            RoleRoleGroups = new HashSet<RoleRoleGroup>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string RoleGroupName { get; set; } = null!;
        public int CompanyId { get; set; }
        [Column("UserTypeID")]
        public int UserTypeId { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [InverseProperty("RoleGroup")]
        public virtual ICollection<RoleRoleGroup> RoleRoleGroups { get; set; }
        [InverseProperty("RoleGroup")]
        public virtual ICollection<User> Users { get; set; }
    }
}
