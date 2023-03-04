using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_CommerceAPI.Models;

public partial class OfferModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int Discount { get; set; } = 0;
}
