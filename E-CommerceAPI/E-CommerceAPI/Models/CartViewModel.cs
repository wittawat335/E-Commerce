using E_CommerceAPI.Entities;
using E_CommerceAPI.Models;
using System;
using System.Collections.Generic;

namespace ECommerce.API.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public List<CartItemViewModel> CartItems { get; set; } = new();
        public bool Ordered { get; set; }
        public string OrderedOn { get; set; } = string.Empty;
    }
}

