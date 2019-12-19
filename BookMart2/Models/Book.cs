using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMart2.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string name { get; set; }
        public int year { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<AuthorToBook> AuthorToBooks { get; set; }

    }
}
