using E_CommerceAPI.Models;
using System;
using System.Collections.Generic;

namespace ECommerce.API.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public UserModel User { get; set; } = new UserModel();
        public List<CartItem> CartItems { get; set; } = new();
        public bool Ordered { get; set; }
        public string OrderedOn { get; set; } = string.Empty;
    }
}

