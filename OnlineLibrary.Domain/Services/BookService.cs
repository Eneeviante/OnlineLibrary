using OnlineLibrary.Domain.Interfaces;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorAsync(Guid authorId)
        {
            return await bookRepository.GetAllByAuthorAsync(authorId);
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await bookRepository.GetAsync(id);
        }

        public async Task<Book> CreateAsync(ushort year, string name)
        {
            Book newBook = new()
            {
                Id = new Guid(),
                Year = year,
                Name = name
            };

            await bookRepository.CreateAsync(newBook);
            return newBook;
        }

        public async Task<Book> DeleteAsync(Guid BookId)
        {
            var Book = await bookRepository.GetAsync(BookId);
            if (Book == null)
            {
                return null;
            }

            var deletedBooking = await bookRepository.DeleteAsync(BookId);
            return deletedBooking;
        }
    }
}
