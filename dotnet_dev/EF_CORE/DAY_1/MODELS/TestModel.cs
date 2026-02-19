using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.MODELS
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Book Book { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

    }
}
