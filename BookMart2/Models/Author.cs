using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMart2.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string name { get; set; }

        public virtual ICollection<AuthorToBook> AuthorToBooks { get; set; }
    }
}
