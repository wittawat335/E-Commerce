using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Role { get; set; } 
    public string Status { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public string ModifiedAt { get; set; } = string.Empty;
}
