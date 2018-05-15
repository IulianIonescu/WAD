using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WADTestApp2.Model;
namespace WADTestApp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=blog.db");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; } 
        public DbSet<AuthorBooks> AuthorBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
