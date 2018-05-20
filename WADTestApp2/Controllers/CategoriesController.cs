using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADTestApp2.Data;
using WADTestApp2.Model;

namespace WADTestApp2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return dbContext.Categories.AsEnumerable();
        }

        // GET: api/Categories/5
        [HttpGet("{id}/Books")]
        public IActionResult Get(int id)
        {
            var retBook = dbContext.Books
                                .Include(book => book.Category).Where(bookcat => bookcat.Category.Id == id)
                                .Include(book => book.AuthorsLinks)
                                .ThenInclude(al => al.Author);

            if (retBook != null)
            {

                return Ok(retBook.AsEnumerable());
            }
            return NotFound();
        }
        
        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
