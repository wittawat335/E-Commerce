using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Entities;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Provider { get; set; }

    public string? Available { get; set; }

    public string? Reason { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
