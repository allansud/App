﻿using System.ComponentModel.DataAnnotations;

namespace App.Identity.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
