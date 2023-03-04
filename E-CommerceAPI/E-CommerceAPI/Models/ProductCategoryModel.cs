using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_CommerceAPI.Models;

public class ProductCategoryModel
{
    public int Id { get; set; }
    public string Category { get; set; } = "";
    public string SubCategory { get; set; } = "";
}
