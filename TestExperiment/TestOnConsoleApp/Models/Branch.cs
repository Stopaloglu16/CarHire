using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Index("AddressId", Name = "IX_Branches_AddressId")]
    public partial class Branch
    {
        public Branch()
        {
            CarHirePickUpBranches = new HashSet<CarHire>();
            CarHireReturnBranches = new HashSet<CarHire>();
            Cars = new HashSet<Car>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        public int AddressId { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Branches")]
        public virtual Address Address { get; set; } = null!;
        [InverseProperty("PickUpBranch")]
        public virtual ICollection<CarHire> CarHirePickUpBranches { get; set; }
        [InverseProperty("ReturnBranch")]
        public virtual ICollection<CarHire> CarHireReturnBranches { get; set; }

        [InverseProperty("Branch")]
        public virtual ICollection<Car> Cars { get; set; }

        [InverseProperty("Branch")]
        public virtual ICollection<User> Users { get; set; }
    }
}
