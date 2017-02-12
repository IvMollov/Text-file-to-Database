using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace OnlineBookStore
{
    class OnlineBookStoreDbContext : DbContext
    {

        public OnlineBookStoreDbContext() : base("name=OnlineBookStoreDbContext")
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
    }
}
