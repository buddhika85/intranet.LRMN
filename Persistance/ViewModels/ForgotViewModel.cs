using System.ComponentModel.DataAnnotations;

namespace Persistance.ViewModels
{

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}