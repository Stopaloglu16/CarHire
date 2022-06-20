using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Domain.Entities.UserAuthAggregate.Register
{
    [NotMapped]
    public class UserRegisterRequest
    {

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 5,
        ErrorMessage = "{0} should be minimum 5 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string Username { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 8,
        ErrorMessage = "{0} should be minimum 8 characters and a maximum of 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 8,
        ErrorMessage = "{0} should be minimum 8 characters and a maximum of 50 characters")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public string TokenConfirm { get; set; }


        public static bool ValidatePassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);

            return isValidated;

        }

    }
}
