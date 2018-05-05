using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADTestApp2.Model
{
    public class AuthorBooks
    {
        public int Id { get; set; }
        public virtual Author Author{ get; set;}
        public virtual Book Book { get; set; }


    }
}
