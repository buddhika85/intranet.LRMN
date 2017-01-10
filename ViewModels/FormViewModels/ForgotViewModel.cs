using System.ComponentModel.DataAnnotations;

namespace ViewModels.FormViewModels
{

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}