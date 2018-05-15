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
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return dbContext.Categories.AsEnumerable();
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var categoryData = dbContext
               .Categories
               .Include("Books")
               .Where(categ => categ.Id == id).FirstOrDefault();
            if (categoryData != null)
            {

                return Ok(categoryData.Books.AsEnumerable());
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
