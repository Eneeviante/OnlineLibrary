﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;

namespace OnlineLibrary.Infrastructure.Context
{
    public class LibraryDBContext : DbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        { }
    }
}
