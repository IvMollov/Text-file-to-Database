using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore
{
    class Parser
    {
        public static Book Prasers(StreamReader reader)
        {
            Book book = new Book();
            Author author = new Author();

            string line = "";
            while ((line = reader.ReadLine()) != "")
            {
                line = line.Replace('.', ',');
                string[] parts = Array.ConvertAll(line.Split('|'), (x => x.Trim()));
                book.BookTitle = parts[0];
                string[] authors = Array.ConvertAll(parts[1].Split(';', ','), (x => x.Trim()));
                foreach (var item in authors)
                {
                    string[] authorsNames = item.Split(new string[] { "", " " }, StringSplitOptions.None);
                    if (authorsNames.Length == 2)
                    {
                        author.FirstName = authorsNames[0];
                        author.LastName = authorsNames[1];
                    }
                    else
                    {
                        author.FirstName = authorsNames[0];
                        author.MiddleName = authorsNames[1];
                        author.LastName = authorsNames[2];
                    }
                }

                book.Authors = new List<Author>() { author };
                book.ISBN = parts[2];
                book.Money = decimal.Parse(parts[3]);
                book.Amount = Convert.ToInt32(parts[4]);
                book.WebSite = parts[5];
                return book;
            }
            return book;
        }

    }
}
