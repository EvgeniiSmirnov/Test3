using Test3.Models.Enums;

namespace Test3.Models;

public class User
{
    public UserType UserType { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
