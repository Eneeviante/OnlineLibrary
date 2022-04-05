using OnlineLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllByAuthorAsync(Guid authorId);
        Task<Book> GetAsync(Guid id);
        Task CreateAsync(Book newBook);
        Task<Book> DeleteAsync(Guid id);
    }
}
