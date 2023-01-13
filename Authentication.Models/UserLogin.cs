﻿using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class UserLogin 
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}