using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Models
{
    public class Book
    {
        Guid Id { get; set; }
        ushort Year { get; set; }
        [MaxLength(30)]
        string Name { get; set; }
        List<Author> Authors { get; set; }
    }
}
