using E_CommerceAPI.Models;
using ECommerce.API.Models;

namespace E_CommerceAPI.DALRepository
{
    public interface IDataAccess
    {
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        Offer GetOffer(int id);
        List<Product> GetProducts(string category, string subcategory, int count);
        Product GetProduct(int id);
        bool InsertUser(UserModel user);
        string IsUserPresent(string email, string password);
        void InsertReview(ReviewModel review);
        List<ReviewModel> GetProductReviews(int productId);
        UserModel GetUser(int id);
        bool InsertCartItem(int userId, int productId);
        Cart GetActiveCartOfUser(int userid);
        Cart GetCart(int cartid);
        List<Cart> GetAllPreviousCartsOfUser(int userid);
        List<PaymentMethod> GetPaymentMethods();
        int InsertPayment(Payment payment);
        int InsertOrder(Order order);
    }
}
