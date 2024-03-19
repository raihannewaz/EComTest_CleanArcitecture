

using EComTest.Domain.CategoryEntity;
using EComTest.Domain.OrderEntity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EComTest.Domain.ProductEntity
{
    public class Product
    {
        [Key]
        public int ProductId { get; private set; }
        public string? ProductName { get; private set; }
        public decimal Price { get; private set;}
        public int CategoryId { get; private set; }

        [JsonIgnore]
        public Category? Category { get;  set; }

        public virtual ICollection<Order>? Order { get; set; }



        public void  CreateProduct(string name, decimal price, int catId)
        {
            ProductName = name;
            Price = price;
            CategoryId = catId;
        }

        public void UpdateProduct(int id, string name, decimal price, int catId)
        {
            ProductId = id;
            ProductName = name;
            Price = price;
            CategoryId = catId;
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
