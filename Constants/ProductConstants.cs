using JWT.Practice.NET.Models;

namespace JWT.Practice.NET.Constants
{
    public class ProductConstants
    {
        public static List<ProductModel> products = new List<ProductModel>()
        {
            new ProductModel{ Title = "Fridge", Price = 230, Description = "The ultimate fridge for your home" },
            new ProductModel{ Title = "Bed", Price = 230, Description = "A comfortable bed, here you have it" },
        };
    }
}