using E_CommerceAPI.Models;

namespace E_CommerceAPI.DALRepository
{
    public interface IDataAccess
    {
        List<ProductCategoryModel> GetProductCategories();
        ProductCategoryModel GetProductCategory(int id);
        OfferModel GetOffer(int id);
        List<ProductModel> GetProducts(string category, string subcategory, int count);
        ProductModel GetProduct(int id);
        bool InsertUser(UserModel user);
        string IsUserPresent(string email, string password);
        void InsertReview(ReviewModel review);
        List<ReviewModel> GetProductReviews(int productId);
        UserModel GetUser(int id);
        bool InsertCartItem(int userId, int productId);
        CartModel GetActiveCartOfUser(int userid);
        CartModel GetCart(int cartid);
        List<CartModel> GetAllPreviousCartsOfUser(int userid);
        List<PaymentMethodModel> GetPaymentMethods();
        int InsertPayment(PaymentModel payment);
        int InsertOrder(OrderModel order);
    }
}
