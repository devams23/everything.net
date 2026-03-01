
using Microsoft.AspNetCore.Mvc;
using WebApplication_api.Services.Service;
using WebApplication_api.Services.Interface;
using WebApplication_api.Services.DTO;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication_api.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize] // All endpoints require authentication

    public class ProductCatalogController : ControllerBase
    {

        private readonly ProductCatalogService productCatalogService;
        private readonly ITransientGUI transientGUIService;
        private readonly ISingletonGUI singletonGUIService;
        private readonly IScopedGUI scopedGUIService;

        private readonly ITransientGUI transientGUIService2;
        private readonly IScopedGUI scopedGUIService2;

        public ProductCatalogController(ProductCatalogService _productCatalogService, IScopedGUI _scopedGUIService2, ITransientGUI _transientGUIService2, ITransientGUI _transientGUIService, ISingletonGUI _singletonGUIService, IScopedGUI _scopedGUIService)
        {
            productCatalogService = _productCatalogService;
            transientGUIService = _transientGUIService;
            singletonGUIService = _singletonGUIService;
            scopedGUIService = _scopedGUIService;
            transientGUIService2 = _transientGUIService2;
            scopedGUIService2 = _scopedGUIService2;


        }

        /// <summary>
        /// Get all products - Accessible to all authenticated users (Admin, Vendor, Customer)
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            var user = User?.Identity?.Name;
            Console.WriteLine($"GetAllProducts called by user: {user}");
            var products = productCatalogService.GetAllProducts();
            return Ok(products);
        }


        /// <summary>
        /// Get product by ID - Accessible to all authenticated users
        /// </summary>
        [HttpGet("{id:int}")]
        [Authorize]
        public IActionResult GetProductById(int id)
        {
            var product = productCatalogService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Get products by category - Accessible to all authenticated users
        /// </summary>
        [HttpGet("category/{categorytype:alpha}")]
        [Authorize]
        public IActionResult GetProductsByCategory(string categorytype)
        {
            Console.WriteLine("category:---" + categorytype);
            var products = productCatalogService.GetProductsByCategory(categorytype);
            return Ok(products);

        }

        /// <summary>
        /// Search products by name - Accessible to all authenticated users
        /// </summary>
        [HttpGet("search")]
        [Authorize]
        public IActionResult GetProductsByName([FromQuery] string name)
        {
            Console.WriteLine("name:---" + name);
            // var products = productCatalogService.GetProductsByName(name);
            return Ok("Products retrieved by name: " + name);

        }

        /// <summary>
        /// Add new product - Accessible only to Admin and Vendor roles
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Vendor")]
        public IActionResult AddProduct(ProductDTO product)
        {

            productCatalogService.AddProduct(product);
            return Ok(new { message = "Product added successfully", product });
        }

        /// <summary>
        /// Delete product - Accessible only to Admin role
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {

            bool result = productCatalogService.RemoveProduct(id);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return Ok("Product deleted successfully.");
        }

        /// <summary>
        /// Update product - Accessible to Admin and Vendor roles
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Vendor")]
        public IActionResult UpdateProduct(int id, ProductDTO product)
        {


            bool result = productCatalogService.UpdateProduct(id, product);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return Ok("Product updated successfully.");
        }

        /// <summary>
        /// Get service lifetimes - Accessible to all authenticated users
        /// </summary>
        [HttpGet("lifetime")]
        [Authorize]
        public IActionResult GetGuiLifetimes()
        {
            var transientGuid = transientGUIService.GetGuid();
            var singletonGuid = singletonGUIService.GetGuid();
            var scopedGuid = scopedGUIService.GetGuid();

            var transientGuid2 = transientGUIService2.GetGuid();

            var scopedGuid2 = scopedGUIService2.GetGuid();
            return Ok(new
            {
                Transient = transientGuid,
                Singleton = singletonGuid,
                Scoped = scopedGuid,

                Transient_ = transientGuid2,

                Scoped_ = scopedGuid2
            });
        }


    }
}
