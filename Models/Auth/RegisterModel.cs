using System.ComponentModel.DataAnnotations;

namespace WinglyShopAdmin.App.Models.Auth;

public class RegisterModel
{
    [Required, MaxLength(20)]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }
}
