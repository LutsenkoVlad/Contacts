using System.ComponentModel.DataAnnotations;

namespace AddressBook.BLL.Models
{
    public class ContactLogViewModel
    {
        [Required]
        [StringLength(28, ErrorMessage = "Must be between 6 and 28 characters", MinimumLength = 6)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(28, ErrorMessage = "Must be between 8 and 28 characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
