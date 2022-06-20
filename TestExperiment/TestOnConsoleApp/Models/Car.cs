using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Index("BranchId", Name = "IX_Cars_BranchId")]
    [Index("CarModelId", Name = "IX_Cars_CarModelId")]
    public partial class Car
    {
        public Car()
        {
            CarHires = new HashSet<CarHire>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string NumberPlates { get; set; } = null!;
        public int BranchId { get; set; }
        public int CarModelId { get; set; }
        public int Gearbox { get; set; }
        public int Mileage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Costperday { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [ForeignKey("BranchId")]
        [InverseProperty("Cars")]
        public virtual Branch Branch { get; set; } = null!;
        [ForeignKey("CarModelId")]
        [InverseProperty("Cars")]
        public virtual CarModel CarModel { get; set; } = null!;
        [InverseProperty("Car")]
        public virtual ICollection<CarHire> CarHires { get; set; }
    }
}
