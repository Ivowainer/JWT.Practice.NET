using JWT.Practice.NET.Models;
using JWT.Practice.NET.Services;
using Microsoft.AspNetCore.Authorization;
using JWT.Practice.NET.Config.Filter;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Practice.NET.Controllers
{
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : Controller
    {
        [HttpGet]
        // Acces only if the user is logged
        [TypeFilter(typeof(AuthorizationFilter))]
        public IActionResult GetProducts()
        {

            var products = productService.GetProducts();

            return Ok(products);
        }

        [HttpPost]
        // Acces only if the user is logged and the userRole is Admin
        [TypeFilter(typeof(AuthorizationFilter))]
        [TypeFilter(typeof(AdminAuthorizationFilter))]
        public IActionResult PostProduct([FromBody] ProductModel productModel)
        {
            try
            {
                var product = productService.CreateProduct(productModel);

                return Ok(product);
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                    return new BadRequestObjectResult(e.Message);

                return new BadRequestObjectResult(e.Message);

            }
        }
    }
}