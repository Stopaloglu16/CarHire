using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarBrandAggregate.Commands.Create
{

    public class CreateCarBrandRequest
    {

        [Required]
        [StringLength(50)]
        public string? BrandName { get; set; }

    }

}
