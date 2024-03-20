using EComTest.Application.OrderCQRS.Command.CreateOrder;
using EComTest.Application.OrderCQRS.Command.DeleteOrder;
using EComTest.Application.OrderCQRS.Command.UpdateOrder;
using EComTest.Application.OrderCQRS.Queries.GetOrderById;
using EComTest.Application.OrderCQRS.Queries.GetOrders;
using EComTest.Application.ProductCQRS.Command.CreateProduct;
using EComTest.Application.ProductCQRS.Command.UpdateProduct;
using EComTest.Application.ProductCQRS.Queries.GetProductById;
using EComTest.Application.ProductCQRS.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EComTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _mediatr;

        public OrderController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var data = await _mediatr.Send(new GetOrdersQuery());
            var json = JsonSerializer.Serialize(data, options);
            return Ok(json);


            //var data = await _mediatr.Send(new GetOrdersQuery());
            //return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var data = await _mediatr.Send(new GetOrderByIdQuery() { OrdId = id });
            if (data == null)
            {
                return NotFound();
            }
            var json = JsonSerializer.Serialize(data, options);
            return Ok(json);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateOrderCommand command)
        {
            var data = await _mediatr.Send(command);
            return Ok(data);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateOrderCommand command)
        {
            if (id != command.OrderId)
            {
                return BadRequest();
            }

            var data = await _mediatr.Send(command);

            return Ok("Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediatr.Send(new DeleteOrderCommand() { OrdId = id });
            return Ok("Deleted!");

        }
    }
}
