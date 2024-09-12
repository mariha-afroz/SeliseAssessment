using System.Diagnostics;
namespace ProductService.Pages
{
    public class ProductService
    {
        public DomainLayer.Models.Product productData { get; set; }
        private readonly DataAccessLayer.Interfaces.IProduct m_Product;

        public ProductService(DataAccessLayer.Interfaces.IProduct productMangr)
        {
            m_Product = productMangr;
        }

        public void FetchProductDetailsById(int productId)
        {
            var product = m_Product.GetProductById(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
        }

        public IList<DomainLayer.Models.Product> FetchListOfProducts()
        {
            try
            {
                var ProductList = m_Product.GetAllProducts();
                return ProductList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task AddNewProduct(DomainLayer.Models.Product product)
        {
            await m_Product.CreateProduct(product);
        }

        public async Task UpdateProductDetails(int productId, DomainLayer.Models.Product updatedProduct)
        {
            var product = m_Product.GetProductById(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            product.ProductName = updatedProduct.ProductName;
            product.ProductDescription = updatedProduct.ProductDescription;
            
            await m_Product.UpdateProduct(product);
        }
    }
}
