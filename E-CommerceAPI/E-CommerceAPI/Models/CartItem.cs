using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }
}
