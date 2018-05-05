using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADTestApp2.Model
{
    public class Book
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AuthorBooks> AuthorsLinks { get; set; }
    }
}
