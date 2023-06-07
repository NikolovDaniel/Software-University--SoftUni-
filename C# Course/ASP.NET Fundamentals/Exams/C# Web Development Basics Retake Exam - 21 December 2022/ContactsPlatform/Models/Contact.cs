using ContactsPlatform.Utilities.Constants;
using ContactsPlatform.Utilities.Messages.ErrorMessages;
using System.ComponentModel.DataAnnotations;

namespace ContactsPlatform.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.FirstNameMaxLength, 
            MinimumLength = DataConstants.FirstNameMinLength,
            ErrorMessage = ErrorMessages.FirstNameErrorMessage)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.LastNameMaxLength,
           MinimumLength = DataConstants.LastNameMinLength,
           ErrorMessage = ErrorMessages.LastNameErrorMessage)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.EmailMaxLength,
          MinimumLength = DataConstants.EmailMinLength,
          ErrorMessage = ErrorMessages.EmailErrorMessage)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.PhoneNumberMaxLength,
          MinimumLength = DataConstants.PhoneNumberMinLength,
          ErrorMessage = ErrorMessages.PhoneNumberErrorMessage)]
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;

        [Required]
        public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;
    }
}