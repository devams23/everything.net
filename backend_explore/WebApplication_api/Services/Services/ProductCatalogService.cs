using System.Collections;
using WebApplication_api.Repository.Interface;
using WebApplication_api.Repository.Models;

namespace WebApplication_api.Services.Services
{
    public class ProductCatalogService
    {
        private readonly IProductRepository _productRepository;

        public ProductCatalogService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (_productRepository.AddProduct(product))
            {
                Console.WriteLine("ADDED PRODUCT SUCCESSFULLY.");
            }
        }

        public bool RemoveProduct(int productId) {
            if (_productRepository.DeleteProduct(productId))
            {
                Console.WriteLine("DELETED PRODUCT SUCCESSFULLY.");
                return true;
            }
            return false;

        }

        public bool UpdateProduct(Product product)
        {
            if (_productRepository.UpdateProduct(product))
            {
                Console.WriteLine("UPDATED PRODUCT SUCCESSFULLY.");
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

            

    }
}
