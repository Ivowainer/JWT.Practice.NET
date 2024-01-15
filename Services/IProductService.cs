using JWT.Practice.NET.Models;

namespace JWT.Practice.NET.Services
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
        ProductModel CreateProduct(ProductModel product);
    }
}