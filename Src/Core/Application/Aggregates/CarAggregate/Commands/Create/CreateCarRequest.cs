using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarAggregate.Commands.Create
{
    public class CreateCarRequest
    {
        public CreateCarRequest(string? numberPlates, int? branchId, int carModelId, Gearbox gearbox, int mileage, decimal costperday = 1)
        {
            NumberPlates = numberPlates;
            BranchId = branchId;
            CarModelId = carModelId;
            Gearbox = gearbox;
            Mileage = mileage;
            Costperday = costperday;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? NumberPlates { get; set; }
        public int? BranchId { get; set; }
        public int CarModelId { get; set; }
        public Gearbox Gearbox { get; set; }
        public int Mileage { get; set; } = 0;

        [Required]
        [Range(0, 999.99)]
        public decimal Costperday { get; set; }


    }
}
