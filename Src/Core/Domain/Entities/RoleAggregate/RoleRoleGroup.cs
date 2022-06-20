using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.RoleAggregate
{
    public class RoleRoleGroup
    {

        [Key]
        public int RoleGroupId { get; set; }

        [Key]
        public int RoleId { get; set; }

        public DateTime HaveSkillSince { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RoleRoleGroups")]
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(RoleGroupId))]
        [InverseProperty("RoleRoleGroups")]
        public virtual RoleGroup RoleGroup { get; set; }

    }
}
