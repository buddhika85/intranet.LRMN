﻿using System.ComponentModel.DataAnnotations;

namespace Persistance.ViewModels
{

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}