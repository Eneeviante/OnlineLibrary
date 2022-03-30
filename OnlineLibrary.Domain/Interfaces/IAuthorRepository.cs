using OnlineLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetAsync(Guid id);
        Task CreateAsync(Author newAuthor);
        Task<Author> DeleteAsync(Guid id);
    }
}
