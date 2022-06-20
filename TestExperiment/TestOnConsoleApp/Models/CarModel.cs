using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Index("CarBrandId", Name = "IX_CarModels_CarBrandId")]
    public partial class CarModel
    {
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }
        public string CarPhoto { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public int CarPhotoLenght { get; set; }
        public int SeatNumber { get; set; }

        public int CarBrandId { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [ForeignKey("CarBrandId")]
        [InverseProperty("CarModels")]
        public virtual CarBrand CarBrand { get; set; } = null!;
        [InverseProperty("CarModel")]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
