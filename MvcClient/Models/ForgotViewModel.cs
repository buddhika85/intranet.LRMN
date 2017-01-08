﻿using System.ComponentModel.DataAnnotations;

namespace MvcClient.Models
{

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}