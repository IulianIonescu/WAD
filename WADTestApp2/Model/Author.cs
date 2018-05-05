using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADTestApp2.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AuthorBooks> BooksLinks { get; set; }
    }
}
