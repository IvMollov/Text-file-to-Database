using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace OnlineBookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertToDatabase();
            Console.WriteLine("Book saved");
            Console.ReadLine();
      
        }

        public static void InsertToDatabase()
        {
            using (var db = new OnlineBookStoreDbContext())
            {
                Book book = new Book();
                Author author = new Author();
                using (StreamReader reader = new StreamReader(@"D:\Projects\OnlineBookStore\Text-file-to-Database\OnlineBookStore\bin\OnlineBook.txt"))
                {
                        book = Parser.Prasers(reader);
                }

                db.Book.Add(book);
                db.SaveChanges();
            }
        }
    }
}
