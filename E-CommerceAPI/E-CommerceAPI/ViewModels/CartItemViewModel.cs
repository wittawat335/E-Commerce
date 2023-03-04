using E_CommerceAPI.Entities;

namespace E_CommerceAPI.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public Product? product { get; set; } = new Product();
    }
}
