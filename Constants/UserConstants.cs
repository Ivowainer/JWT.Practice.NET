using JWT.Practice.NET.Models;

namespace JWT.Practice.NET.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){ Username = "jperez", Password = "admin123", Role = "Administrator", EmailAddress = "jperez@gmail.com", FirstName = "Juan", LastName = "Perez" },
            new UserModel(){ Username = "mgonzalez", Password = "admin123", Role = "Seller", EmailAddress = "mgonzalez@gmail.com", FirstName = "Maria", LastName = "Gonzales" }
        };
    }
}