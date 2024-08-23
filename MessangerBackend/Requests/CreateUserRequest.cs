namespace MessangerBackend.Requests;

public class CreateUserRequest
{
    public string Nickname { get; set; }
    public string Password { get; set; }
}