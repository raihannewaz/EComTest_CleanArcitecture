using EComTest.Domain.ProductEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EComTest.Domain.OrderEntity
{
    public class Order
    {
        [Key]
        public int OrderId { get; private set; }

        public int Quantity { get; private set; }

        public decimal Total { get; private set; }

        public int ProductId { get; private set; }

        [JsonIgnore]
        public Product? Product { get; set; }


        
        
       

        public void CreateOrder(int quantity, int productId)
        {
            Quantity = quantity;
            ProductId = productId;
            if (Product != null)
            {
                Total = quantity * Product.Price;
            }
        }

        public void UpdateOrder(int orderid, int quantity, int productId)
        {

            OrderId = orderid;
            Quantity = quantity;
            ProductId = productId;
            if (Product != null)
            {
                Total = quantity * Product.Price;
            }
        }

        public void UpdateQuantityAndTotal(int quantity)
        {
            if (quantity != null)
            {
                Quantity = quantity;

                if (Product != null)
                {
                    Total = quantity * Product.Price;
                }
            }
        }

        public void UpdateProductId(int productid)
        {
            ProductId = productid;
        }
    }
}
