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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository _authorRepository)
        {
            authorRepository = _authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await authorRepository.GetAllAsync();
        }

        public async Task<Author> CreateAsync(string lastName)
        {
            Author newAuthor = new()
            {
                Id = new Guid(),
                LastName = lastName
            };

            await authorRepository.CreateAsync(newAuthor);
            return newAuthor;
        }

        public async Task<Author> DeleteAsync(Guid authorId)
        {
            var author = await authorRepository.GetAsync(authorId);
            if (author == null)
            {
                return null;
            }

            var deletedBooking = await authorRepository.DeleteAsync(authorId);
            return deletedBooking;
        }
    }
}
