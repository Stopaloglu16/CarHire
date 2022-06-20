using Domain.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CardDetailAggregate.EndPoints
{
    public class CardDetailRequest : IMapFrom<CardDetail>
    {
        public CardDetailRequest()
        {

        }
        public CardDetailRequest(int _Id, string _CardNumber, DateTime _ExpieryDate, string _CardVerificationValue)
        {
            Id = _Id;
            CardNumber = _CardNumber;
            ExpieryDate = _ExpieryDate;
            CardVerificationValue = _CardVerificationValue;
        }


        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(16)]
        public string CardNumber { get; }

        [Required]
        public DateTime ExpieryDate { get; }

        [Required]
        [StringLength(3, ErrorMessage = "Need 3 chars", MinimumLength = 3)]
        public string CardVerificationValue { get; }

    }
}
