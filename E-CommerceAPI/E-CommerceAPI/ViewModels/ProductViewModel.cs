namespace E_CommerceAPI.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public int OfferId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ImageName { get; set; } = null!;
        //public ProductCategoryViewModel Category { get; set; } = new ProductCategoryViewModel();
        //public OfferViewModel Offer { get; set; } = new OfferViewModel();
    }
}
