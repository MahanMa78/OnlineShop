using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DTOs;

public class UserForRegistrationDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [Required(ErrorMessage ="Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Compare("Password", ErrorMessage = "The Password and confirmation password do not match.")]
    public string? ConfirmPassword{ get; set; }
}
