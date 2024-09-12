using DomainLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IProduct
    {
        Task<int> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Product GetProductById(int productId);
        IList<Product> GetAllProducts();
    }
}
