using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class PaymentModel
{
    public int Id { get; set; }
    public PaymentMethodModel PaymentMethod { get; set; } = new PaymentMethodModel();
    public UserModel User { get; set; } = new UserModel();
    public int TotalAmount { get; set; }
    public int ShipingCharges { get; set; }
    public int AmountReduced { get; set; }
    public int AmountPaid { get; set; }
    public string CreatedAt { get; set; } = string.Empty;
}
