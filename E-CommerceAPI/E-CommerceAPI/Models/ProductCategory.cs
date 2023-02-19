using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public partial class ProductCategory
{
    public int CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public string SubCategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
