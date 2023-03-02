﻿using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class Payment
{
    public int Id { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();
    public UserModel User { get; set; } = new UserModel();
    public int TotalAmount { get; set; }
    public int ShipingCharges { get; set; }
    public int AmountReduced { get; set; }
    public int AmountPaid { get; set; }
    public string CreatedAt { get; set; } = string.Empty;
}
