using Domain.Common;
using Domain.Entities.BranchAggregate;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.AddressAggregate
{
    public class Address : BaseEntity<int>
    {

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Address1 { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? City { get; set; }


        [Required]
        [Column(TypeName = "varchar(10)")]
        public string? Postcode { get; set; }


        public AddressType addressType { get; set; }

        public virtual ICollection<Branch> Branches { get; private set; } = new List<Branch>();
        public virtual ICollection<User> Users { get; private set; } = new List<User>();


    }
}
