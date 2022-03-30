using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Models
{
    public class Author
    {
        Guid Id { get; set; }
        string LastName { get; set; }
    }
}
