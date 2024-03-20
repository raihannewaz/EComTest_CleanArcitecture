using EComTest.Application.CategoryCQRS.Command.CreateCategory;
using EComTest.Application.CategoryCQRS.Command.DeleteCategory;
using EComTest.Application.CategoryCQRS.Command.UpdateCategory;
using EComTest.Application.CategoryCQRS.Queries.GetCategories;
using EComTest.Application.CategoryCQRS.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISender _mediatr;

        public CategoryController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _mediatr.Send(new GetCategoryQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _mediatr.Send(new GetCategoryByIdQuery() { CatId = id});
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateCategoryCommand command)
        {
            var data = await _mediatr.Send(command);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateCategoryCommand command)
        {
            if (id != command.CategoryId)
            {
                return BadRequest();
            }

            var data = await _mediatr.Send(command);

            return Ok("Updated!");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediatr.Send(new DeleteCategoryCommand() { CatId = id });
            return Ok("Deleted!");

        }
    }
}
