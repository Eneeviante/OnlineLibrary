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
        public Guid Id { get; set; }
        public ushort Year { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
    }
}
