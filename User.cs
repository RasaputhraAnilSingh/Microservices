using System;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; } // In real-world applications, passwords should be hashed!
    public string Role { get; set; } // Roles: "Admin" or "User"
}
