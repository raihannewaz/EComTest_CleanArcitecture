using EComTest.Application.CategoryCQRS.Command.CreateCategory;
using EComTest.Application.CategoryCQRS.Command.UpdateCategory;
using EComTest.Application.CategoryCQRS.Queries.GetCategories;
using EComTest.Application.CategoryCQRS.Queries.GetCategoryById;
using EComTest.Application.OrderCQRS.Command.DeleteOrder;
using EComTest.Application.ProductCQRS.Command.CreateProduct;
using EComTest.Application.ProductCQRS.Command.DeleteProduct;
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
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediatr;

        public ProductController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _mediatr.Send(new GetProductQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _mediatr.Send(new GetProductByIdQuery() { ProdId = id });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateProductCommand command)
        {
            var data = await _mediatr.Send(command);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateProductCommand command)
        {
            if (id != command.CategoryId)
            {
                return BadRequest();
            }

            var data = await _mediatr.Send(command);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediatr.Send(new DeleteProductCommand() { prodId = id });
            return NoContent();

        }
    }
}
