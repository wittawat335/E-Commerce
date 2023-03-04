
using E_CommerceAPI.Models;
using System;
using System.Collections.Generic;



public class ReviewModel
{
    public int Id { get; set; }
    public UserModel User { get; set; } = new UserModel();
    public ProductModel Product { get; set; } = new ProductModel();
    public string Value { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
}
