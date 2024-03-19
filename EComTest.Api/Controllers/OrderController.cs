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
            var data = await _mediatr.Send(new GetOrdersQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _mediatr.Send(new GetOrderByIdQuery() { OrdId = id });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
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

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediatr.Send(new DeleteOrderCommand() { OrdId = id });
            return NoContent();

        }
    }
}
