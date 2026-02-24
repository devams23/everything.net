using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_api.Repository.Models;
using WebApplication_api.Services.Services;
using WebApplication_api.Services.Interface;


namespace WebApplication_api.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductCatalogController : ControllerBase
    {

        private readonly ProductCatalogService productCatalogService;
        private readonly ITransientGUI transientGUIService;
        private readonly ISingletonGUI singletonGUIService;
        private readonly IScopedGUI scopedGUIService;


        public ProductCatalogController(ProductCatalogService _productCatalogService , ITransientGUI _transientGUIService, ISingletonGUI _singletonGUIService, IScopedGUI _scopedGUIService)
        {
            productCatalogService = _productCatalogService;
            transientGUIService = _transientGUIService;
            singletonGUIService = _singletonGUIService;
            scopedGUIService = _scopedGUIService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = productCatalogService.GetAllProducts();
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = productCatalogService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("category/{categorytype:alpha}")]
        public IActionResult GetProductsByCategory(string categorytype)
        {
            Console.WriteLine("category:---" + categorytype);
            var products = productCatalogService.GetProductsByCategory(categorytype);
            return Ok(products);

        }



        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productCatalogService.AddProduct(product);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            bool result = productCatalogService.RemoveProduct(id);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return Ok("Product deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product) { 

            bool result = productCatalogService.UpdateProduct(product);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return Ok("Product updated successfully.");
        }

        [HttpGet("lifetime")]
        public IActionResult GetGuiLifetimes()
        {
            var transientGuid = transientGUIService.GetGuid();
            var singletonGuid = singletonGUIService.GetGuid();
            var scopedGuid = scopedGUIService.GetGuid();

            return Ok(new
            {
                Transient = transientGuid,
                Singleton = singletonGuid,
                Scoped = scopedGuid
            });
        }
    }
}
