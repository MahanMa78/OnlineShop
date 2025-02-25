namespace OnlineShop.DTOs;

public class AuthenticationResponseDTO
{
    //public string Email { get; set; }
    //public string Status { get; set; }
    //public string Token { get; set; }
    //public string RefreshToken { get; set; }
    //public DateTime TokenExpirationTime { get; set; }
    //public DateTime RefreshTokenExpirationTime { get; set; }
    public string ErrorMessage { get; internal set; }
    public bool IsSuccessfulAuthentication { get; set; }
    //public IEnumerable<string>? Errors { get; set; }
}
