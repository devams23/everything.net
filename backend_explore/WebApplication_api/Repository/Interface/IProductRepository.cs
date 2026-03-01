using WebApplication_api.Repository.Models.Entities;

namespace WebApplication_api.Repository.Interface
{
    public interface IProductRepository
    {
            IEnumerable<Product> GetAllProducts();
            Product GetProductById(int id);
            IEnumerable<Product> GetProductsByCategory(string category);
            bool AddProduct(Product product);
            bool UpdateProduct(Product product);
            bool DeleteProduct(int id);

    }
}
