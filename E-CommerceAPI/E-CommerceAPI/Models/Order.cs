using ECommerce.API.Models;
using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class Order
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public Cart Cart { get; set; } = new Cart();
    public Payment Payment { get; set; } = new Payment();
    public string CreatedAt { get; set; } = string.Empty;
}
