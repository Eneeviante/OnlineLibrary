using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Domain.Services.ServiceInterfaces;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService bookService;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAllByAuthorAsync(Guid authorId)
        {
            var books = await bookService.GetAllByAuthorAsync(authorId);

            return new ObjectResult(books);
        }

        [HttpGet("/books/{bookId}")]
        public async Task<IActionResult> GetAsync(Guid bookId)
        {
            var book = await bookService.GetAsync(bookId);

            if(book == null)
            {
                return BadRequest("The book does not exist!");
            }

            return new ObjectResult(book);
        }

        [HttpPost("{year}, {name}")]
        public async Task<IActionResult> CreateAsync(ushort year, string name)
        {
            var newBook = await bookService.CreateAsync(year, name);

            return CreatedAtRoute(new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deletedBook = await bookService.DeleteAsync(id);

            if (deletedBook == null)
            {
                return BadRequest("The book does not exist!");
            }

            return new ObjectResult(deletedBook);
        }
    }
}
