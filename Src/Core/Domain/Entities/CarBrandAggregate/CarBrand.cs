using Domain.Common;
using Domain.Entities.CarModelAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.CarBrandsAggregate
{
    public class CarBrand : BaseEntity<int>
    {

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }

        public virtual ICollection<CarModel> CarModels { get; private set; } = new List<CarModel>();

    }
}
