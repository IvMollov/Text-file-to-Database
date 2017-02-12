using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore
{
    class Book
    {
        [Key]
        public int BookID { get; set; }

        public string BookTitle { get; set; }

        public List<Author> Authors{ get; set; }

        public string ISBN { get; set; }

        public decimal Money { get; set; }

        public int Amount { get; set; }

        public string WebSite { get; set; }

    }
}
