using System;
using System.Collections.Generic;

namespace E_CommerceAPI.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProductCategoryModel ProductCategory { get; set; } = new ProductCategoryModel();
    public OfferModel Offer { get; set; } = new OfferModel();
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string ImageName { get; set; } = string.Empty;
}
