using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OnlineLibrary.Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public List<Book> Books { get; set; }
    }
}
