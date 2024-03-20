

using EComTest.Domain.CategoryEntity;
using EComTest.Domain.OrderEntity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EComTest.Domain.ProductEntity
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string? ProductName { get; private set; }
        public decimal Price { get; private set;}

        public int CategoryId { get; private set; }
        public Category? Category { get;  set; }


        private Product()
        {

        }

        private Product(string? productName, decimal price, int categoryId)
        {
            ProductName = productName;
            Price = price;
            CategoryId = categoryId;
        }

        public static Product  CreateProduct(string name, decimal price, int catId)
        {
            return new Product(name, price, catId);
        }

 


        public void UpdateProductName(string newName)
        {
            ProductName = newName;
        }


        public void UpdateProductPrice(decimal newPrice)
        {
            Price = newPrice;
        }

        public void UpdateCategoryId(int id)
        {
            CategoryId = id;
        }

    }
}
