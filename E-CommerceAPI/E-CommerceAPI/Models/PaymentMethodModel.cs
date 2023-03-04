using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public class PaymentMethodModel
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public bool Available { get; set; }
    public string Reason { get; set; } = string.Empty;
}