using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Index("AddressId", Name = "IX_Users_AddressId")]
    [Index("BranchId", Name = "IX_Users_BranchId")]
    [Index("CardDetailId", Name = "IX_Users_CardDetailId")]
    [Index("RoleGroupId", Name = "IX_Users_RoleGroupId")]
    public partial class User
    {
        public User()
        {
            CarHires = new HashSet<CarHire>();
            RefreshTokens = new HashSet<RefreshToken>();
            Roles = new HashSet<Role>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string FullName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string UserName { get; set; } = null!;
        [StringLength(250)]
        [Unicode(false)]
        public string UserEmail { get; set; } = null!;
        public int UserTypeId { get; set; }
        [Column("userType")]
        public int UserType { get; set; }
        public int RoleGroupId { get; set; }
        public string AspId { get; set; } = null!;
        public int CompanyId { get; set; }
        public string RegisterToken { get; set; } = null!;
        public DateTime RegisterTokenValid { get; set; }
        public int? BranchId { get; set; }
        public int? AddressId { get; set; }
        public int? CardDetailId { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Users")]
        public virtual Address? Address { get; set; }
        [ForeignKey("BranchId")]
        [InverseProperty("Users")]
        public virtual Branch? Branch { get; set; }
        [ForeignKey("CardDetailId")]
        [InverseProperty("Users")]
        public virtual CardDetail? CardDetail { get; set; }
        [ForeignKey("RoleGroupId")]
        [InverseProperty("Users")]
        public virtual RoleGroup RoleGroup { get; set; } = null!;
        [InverseProperty("User")]
        public virtual ICollection<CarHire> CarHires { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        [ForeignKey("UsersId")]
        [InverseProperty("Users")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
