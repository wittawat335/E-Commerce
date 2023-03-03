using E_CommerceAPI.Entities;
using System;
using System.Collections.Generic;



public partial class CartItemViewModel
{
    public int Id { get; set; }
    public Product? product { get; set; } = new Product();
}
