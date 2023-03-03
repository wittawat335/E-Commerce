using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_CommerceAPI.Entities;

public partial class Offer
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Discount { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
