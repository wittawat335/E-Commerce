using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_CommerceAPI.Entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public string SubCategory { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
