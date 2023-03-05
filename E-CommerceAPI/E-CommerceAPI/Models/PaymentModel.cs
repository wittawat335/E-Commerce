using E_CommerceAPI.Entities;
using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class PaymentModel
{
    public int Id { get; set; }
    public PaymentMethodModel PaymentMethod { get; set; } = new PaymentMethodModel();
    public UserModel User { get; set; } = new UserModel();
    public decimal TotalAmount { get; set; }
    public decimal ShippingCharges { get; set; }
    public decimal AmountReduced { get; set; }
    public decimal AmountPaid { get; set; }
    public string CreatedAt { get; set; } = string.Empty;

}
