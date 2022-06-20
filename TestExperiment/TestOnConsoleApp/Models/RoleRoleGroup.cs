using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Table("RoleRoleGroup")]
    [Index("RoleId", Name = "IX_RoleRoleGroup_RoleId")]
    public partial class RoleRoleGroup
    {
        [Key]
        public int RoleGroupId { get; set; }
        [Key]
        public int RoleId { get; set; }
        public DateTime HaveSkillSince { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("RoleRoleGroups")]
        public virtual Role Role { get; set; } = null!;
        [ForeignKey("RoleGroupId")]
        [InverseProperty("RoleRoleGroups")]
        public virtual RoleGroup RoleGroup { get; set; } = null!;
    }
}
