using WebApplication_api.Data;
using WebApplication_api.Repository.Interface;
using WebApplication_api.Repository.Models;

namespace WebApplication_api.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.products;
        }

        public Product GetProductById(int id)
        {

            return _context.products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            string formattedcategory = category.ToLower();
            return _context.products.Where(p => p.Category.ToLower() == formattedcategory);
        }

        public bool AddProduct(Product product)
        {
            if (product != null)
            {
                _context.products.Add(product);
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = _context.products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                return true;
            }
            return false;
        }
        public bool DeleteProduct(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                
                _context.products.Remove(product);
                return true;
            }
            return false;
        }

    }
}