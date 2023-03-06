using E_CommerceAPI.Entities;

namespace E_CommerceAPI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public int OfferId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ImageName { get; set; } = null!;

        public virtual ProductCategory ProductCategory { get; set; } = null!;

        public virtual Offer Offer { get; set; } = null!;
    }
}
