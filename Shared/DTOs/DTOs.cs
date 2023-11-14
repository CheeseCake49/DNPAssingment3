namespace Shared.DTOs;

public class DTOs
{
    public record UserCreationDTO(string Username, string Password);

    public record PostCreationDTO(string Title, string Body, string OwnerUsername);
    
    public record UserLoginDTO(string Username, string Password);
}