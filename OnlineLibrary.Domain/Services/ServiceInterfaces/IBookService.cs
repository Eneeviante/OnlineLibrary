using OnlineLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Services.ServiceInterfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllByAuthorAsync(Guid authorId);
        Task<Book> GetAsync(Guid id);
        Task<Book> CreateAsync(ushort year, string name);
        Task<Book> DeleteAsync(Guid id);
    }
}
