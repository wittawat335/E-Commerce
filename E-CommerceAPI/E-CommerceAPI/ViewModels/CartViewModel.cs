using E_CommerceAPI.Entities;

namespace E_CommerceAPI.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public List<CartItemViewModel> CartItems { get; set; } = new();
        public bool Ordered { get; set; }
        public string OrderedOn { get; set; } = string.Empty;

    }
}
