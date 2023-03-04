using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; } = new UserModel();
        public List<CartItemModel> CartItems { get; set; } = new();
        public bool Ordered { get; set; }
        public string OrderedOn { get; set; } = string.Empty;
    }
}
