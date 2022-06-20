using Domain.Common;
using Domain.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.CardDetailAggregate
{
    public class CardDetail : BaseEntity<int>
    {


        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ExpieryDate { get; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CardVerificationValue { get; }

        public virtual ICollection<User> Users { get; private set; } = new List<User>();


    }

}
