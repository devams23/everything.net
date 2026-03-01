using AutoMapper;
using Mapster;
using WebApplication_api.Repository.Interface;
using WebApplication_api.Repository.Models.Entities;
using WebApplication_api.Services.DTO;

namespace WebApplication_api.Services.Service
{
    public class ProductCatalogService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductCatalogService(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddProduct(ProductDTO productdto)
        {

            Product product = productdto.Adapt<Product>(); 
            
            //Product product = _mapper.Map<Product>(productdto);

            if (_productRepository.AddProduct(product))
            {
                Console.WriteLine("ADDED Product SUCCESSFULLY.");
            }
        }

        public bool RemoveProduct(int productId) {
            if (_productRepository.DeleteProduct(productId))
            {
                Console.WriteLine("DELETED Product SUCCESSFULLY.");
                return true;
            }
            return false;

        }

        public bool UpdateProduct(int id, ProductDTO productdto)
        {
            //Product product = _mapper.Map<Product>(productdto);
            Product product = productdto.Adapt<Product>();
            product.Id = id;
            
            if (_productRepository.UpdateProduct(product))

            {
                Console.WriteLine("UPDATED Produc SUCCESSFULLY.");
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _productRepository.GetAllProducts();
        }

        public ProductDTO GetProductById(int id)
        {
            Product p = _productRepository.GetProductById(id);
           // ProductDTO productDTO = _mapper.Map<ProductDTO>(p);
            ProductDTO productDTO = p.Adapt<ProductDTO>();
            Console.WriteLine(productDTO.Name);
            return productDTO;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

            

    }
}
