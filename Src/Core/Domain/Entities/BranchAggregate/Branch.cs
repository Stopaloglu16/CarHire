using Domain.Common;
using Domain.Entities.AddressAggregate;
using Domain.Entities.CarAggregate;
using Domain.Entities.CarHireAggregate;
using Domain.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.BranchAggregate
{
    public class Branch : BaseEntity<int>
    {

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string BranchName { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }


        public virtual ICollection<User> Users { get; private set; } = new List<User>();

        public virtual ICollection<Car> Cars { get; private set; } = new List<Car>();


        [InverseProperty("PickUpBranch")]
        public ICollection<CarHireObj> PickUpBranchs { get; set; }

        [InverseProperty("ReturnBranch")]
        public ICollection<CarHireObj> ReturnBranchs { get; private set; }

    }
}
