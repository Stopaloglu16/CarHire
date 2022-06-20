using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    public partial class Address
    {
        public Address()
        {
            Branches = new HashSet<Branch>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Address1 { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string City { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string Postcode { get; set; } = null!;
        [Column("addressType")]
        public int AddressType { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [InverseProperty("Address")]
        public virtual ICollection<Branch> Branches { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<User> Users { get; set; }
    }
}
