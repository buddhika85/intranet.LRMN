using Persistance.DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util;

namespace Persistance.ViewModels
{

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address line 1")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string AddressLine1 { get; set; }

        [Required]
        [Display(Name = "Address line 2")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Address line 3")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string AddressLine3 { get; set; }

        [Required]
        [Display(Name = "County/Region")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string CountyOrRegion { get; set; }

        [Required(ErrorMessage = "Country must be selected.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        [Required]
        [Display(Name = "Post/Zip code")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Postcode { get; set; }

        [Display(Name = "Your volunteer intrests")]
        public string VolunteerInterests { get; set; }

        [Required(ErrorMessage = "Please select a contact type.")]
        [Display(Name = "Contact Type")]
        public int ContactTypeId { get; set; }

        public IEnumerable<ContactType> ContactTypes { get; set; }
    }
}