using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    public partial class CardDetail
    {
        public CardDetail()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [InverseProperty("CardDetail")]
        public virtual ICollection<User> Users { get; set; }
    }
}
