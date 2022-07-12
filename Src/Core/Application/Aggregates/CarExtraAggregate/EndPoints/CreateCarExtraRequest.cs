using Domain.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CarExtraAggregate.EndPoints
{
    public class CreateCarExtraRequest : IMapFrom<CarExtra>
    {
        public CreateCarExtraRequest()
        { }
        public CreateCarExtraRequest(int _Id, string _Name, decimal _Cost)
        {
            Id = _Id;
            Name = _Name;
            Cost = _Cost;
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

    }
}
