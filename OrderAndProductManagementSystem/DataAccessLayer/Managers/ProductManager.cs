using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccessLayer.Managers
{
    public class ProductManager : IProduct
    {
        private readonly OrderProductDbModel _DbModel;

        public ProductManager(OrderProductDbModel DbModel)
        {
            _DbModel = DbModel;
        }

        public async Task<int> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                _DbModel.Add<Product>(product);
                await _DbModel.SaveChangesAsync();

                _DbModel.Entry<Product>(product).State = EntityState.Detached;
                return product.Id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                if (!_DbModel.Entry<Product>(product).IsKeySet)
                    throw new ArgumentException("Product must have an ID set for an update operation.", nameof(product));

                _DbModel.Update<Product>(product);
                await _DbModel.SaveChangesAsync();

                _DbModel.Entry<Product>(product).State = EntityState.Detached;
                return product ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
        public Product GetProductById(int productId)
        {
            try
            {
                return _DbModel.Set<Product>().Find(productId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
        public IList<Product> GetAllProducts()
        {
            try
            {
                return _DbModel.Set<Product>().AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}

