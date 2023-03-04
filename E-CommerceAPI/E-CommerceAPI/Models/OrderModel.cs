using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class OrderModel
{
    public int Id { get; set; }
    public UserModel User { get; set; } = new UserModel();
    public CartModel Cart { get; set; } = new CartModel();
    public PaymentModel Payment { get; set; } = new PaymentModel();
    public string CreatedAt { get; set; } = string.Empty;
}
