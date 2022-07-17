using Domain.Common;
using Domain.Entities.CarBrandsAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.CarModelAggregate
{
    public class CarModel : BaseEntity<int>
    {

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public string? CarPhoto { get; set; }
        public int? CarPhotoLenght { get; set; }

        public int SeatNumber { get; set; }

        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }

    }
}
