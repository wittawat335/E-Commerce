using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Entities;

public partial class Offer
{
    public int OfferId { get; set; }

    public string Title { get; set; } = null!;

    public int Discount { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
