using EComTest.Domain.ProductEntity;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EComTest.Domain.OrderEntity
{
    public class Order
    {
        public int OrderId { get; private set; }

        public int Quantity { get; private set; }

        public decimal Total { get; private set; }

        public int ProductId { get; private set; }

        public Product? Product { get; set; }



        private Order() { }

        private Order(int quantity, int productId)
        {
            Quantity = quantity;
            ProductId = productId;
        }

        public static Order CreateOrder(int quantity, int productId)
        {
            return new Order(quantity, productId); 
        }


        public static async Task CalculateTotalAsync(IProductRepository productRepository)
        {
            var o=new Order();

            if (o.ProductId == 0 || productRepository == null)
            {
                throw new InvalidOperationException("ProductId or product repository is not set.");
            }

            var product = await productRepository.GetById(o.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {o.ProductId} not found.");
            }

            o.Total = o.Quantity * product.Price;
        }



        public void UpdateQuantityAndTotal(int quantity)
        {
            Quantity = quantity;
        }

        public void UpdateProductId(int productid)
        {
            ProductId = productid;
        }
    }
}
