using Domain.Common;
using Domain.Entities.BranchAggregate;
using Domain.Entities.CarHireAggregate;
using Domain.Entities.CarModelAggregate;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.CarAggregate
{
    public class Car : BaseEntity<int>
    {
        public Car()
        {
            CarHires = new HashSet<CarHire>();
        }


        [Required]
        [Column(TypeName = "varchar(10)")]
        public string? NumberPlates { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

        public Gearbox Gearbox { get; set; }

        public int Mileage { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costperday { get; set; }


        public virtual ICollection<CarHire> CarHires { get; private set; } = new List<CarHire>();

    }
}
