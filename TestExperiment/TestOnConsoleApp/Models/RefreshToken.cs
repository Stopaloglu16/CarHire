using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOnConsoleApp.Models
{
    [Table("RefreshToken")]
    [Index("UserId", Name = "IX_RefreshToken_UserId")]
    public partial class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("RefreshTokens")]
        public virtual User User { get; set; } = null!;
    }
}
