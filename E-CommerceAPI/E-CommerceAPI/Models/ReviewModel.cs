using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public class ReviewModel
{
    public int Id { get; set; }
    public UserModel User { get; set; } = new UserModel();
    public Product Product { get; set; } = new Product();
    public string Value { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
}
