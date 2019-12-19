using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMart2.Models
{
    public class AuthorToBook
    {

        public int AuthorToBookId { get; set; }

        public int AuthorId {get;set;}
        public int BookId { get; set; }

        public virtual Author Authors { get; set; }
        public virtual Book Books { get; set; }

    }
}
