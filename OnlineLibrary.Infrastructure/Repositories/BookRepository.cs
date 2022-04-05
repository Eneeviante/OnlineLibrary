using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Interfaces;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Infrastructure.Context;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDBContext context;

        public BookRepository(LibraryDBContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorAsync(Guid id)
        {
            return await context.Authors
                .Where(a => a.Id == id)
                .SelectMany(a => a.Books)
                .ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await context.Books
                .FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task CreateAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task<Book> DeleteAsync(Guid id)
        {
            Book book = await GetAsync(id);

            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }

            return book;
        }
    }
}
