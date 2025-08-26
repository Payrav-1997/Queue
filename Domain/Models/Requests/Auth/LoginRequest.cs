namespace Domain.Models.Requests.Auth;

public class LoginRequest
{
    public string Phone { get; set; } = default!;
    public string Password { get; set; } = default!;
}