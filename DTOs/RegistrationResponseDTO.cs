namespace OnlineShop.DTOs;

public class RegistrationResponseDTO
{
    public bool IsSuccessfulRegistration { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
