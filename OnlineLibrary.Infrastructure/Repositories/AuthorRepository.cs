using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Interfaces;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDBContext context;

        public AuthorRepository(LibraryDBContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<Author> GetAsync(Guid id)
        {
            return await context.Authors
                .FirstOrDefaultAsync(author => author.Id == id);
        }

        public async Task CreateAsync(Author author)
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync();
        }

        public async Task<Author> DeleteAsync(Guid id)
        {
            Author author = await GetAsync(id);

            if (author != null)
            {
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
            }

            return author;
        }
    }
}
