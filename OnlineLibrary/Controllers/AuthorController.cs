using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Domain.Services.ServiceInterfaces;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorService authorService;

        public AuthorController(IAuthorService _authorService)
        {
            authorService = _authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var authors = await authorService.GetAllAsync();

            return new ObjectResult(authors);
        }

        [HttpPost("{lastName}")]
        public async Task<IActionResult> CreateAsync(string lastName)
        {
            var newAuthor = await authorService.CreateAsync(lastName);

            return CreatedAtRoute(new { id = newAuthor.Id }, newAuthor);
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAsync(Guid authorId)
        {
            var deletedAuthor = await authorService.DeleteAsync(authorId);

            if (deletedAuthor == null)
            {
                return BadRequest("The auhtor does not exist!");
            }

            return new ObjectResult(deletedAuthor);
        }
    }
}
