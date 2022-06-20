using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Index("CarId", Name = "IX_CarHires_CarId")]
    [Index("PickUpBranchId", Name = "IX_CarHires_PickUpBranchId")]
    [Index("ReturnBranchId", Name = "IX_CarHires_ReturnBranchId")]
    [Index("UserId", Name = "IX_CarHires_UserId")]
    public partial class CarHire
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public int PickUpBranchId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public bool PickUpConfirmed { get; set; }
        public int ReturnBranchId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public bool ReturnConfirmed { get; set; }
        public int ReturnMileage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BookingCost { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [ForeignKey("CarId")]
        [InverseProperty("CarHires")]
        public virtual Car Car { get; set; } = null!;
        [ForeignKey("PickUpBranchId")]
        [InverseProperty("CarHirePickUpBranches")]
        public virtual Branch PickUpBranch { get; set; } = null!;
        [ForeignKey("ReturnBranchId")]
        [InverseProperty("CarHireReturnBranches")]
        public virtual Branch ReturnBranch { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("CarHires")]
        public virtual User User { get; set; } = null!;
    }
}
