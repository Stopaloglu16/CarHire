using Domain.Entities.CarExtraAggregate;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CarHireAggregate
{
    public class CarHireExtra
    {
        [Key]
        public int CarHireId { get; set; }
        public CarHire CarHire { get; set; }

        [Key]
        public int CarExtraId { get; set; }
        public CarExtra CarExtra { get; set; }

        public decimal ExtraCost { get; set; }

    }
}
