using ECommerce.API.Models;
using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class Order
{
    public int Id { get; set; }
    public UserModel User { get; set; } = new UserModel();
    public CartViewModel Cart { get; set; } = new CartViewModel();
    public Payment Payment { get; set; } = new Payment();
    public string CreatedAt { get; set; } = string.Empty;
}
