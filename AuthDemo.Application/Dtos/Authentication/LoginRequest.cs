﻿using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Application.Dtos.Authentication
{
    public class LoginRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
