using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class CartItem
{
    public int Id { get; set; }
    public Product Product { get; set; } = new Product();
}
