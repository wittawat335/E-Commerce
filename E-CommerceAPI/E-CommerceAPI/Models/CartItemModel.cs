namespace E_CommerceAPI.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; } = new ProductModel();
    }
}
