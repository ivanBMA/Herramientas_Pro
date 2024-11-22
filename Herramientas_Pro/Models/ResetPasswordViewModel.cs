﻿namespace Herramientas_Pro.Models;
using System.ComponentModel.DataAnnotations;

public class ResetPasswordViewModel
{
    [Required]
    public string Token { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
