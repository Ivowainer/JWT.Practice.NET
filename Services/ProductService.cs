using JWT.Practice.NET.Constants;
using JWT.Practice.NET.Models;

namespace JWT.Practice.NET.Services
{
    public class ProductService : IProductService
    {
        public List<ProductModel> GetProducts()
        {
            return ProductConstants.products;
        }

        public ProductModel CreateProduct(ProductModel product)
        {
            if (product.Title.Length < 6)
                throw new ArgumentException("The title must contain at least 6 characters");

            ProductConstants.products.Add(product);
            return product;
        }

    }
}