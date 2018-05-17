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
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            
            var retVal = _context.Books
                                 .Include(book => book.Category)
                                .Include(book => book.AuthorsLinks)
                                    .ThenInclude(al => al.Author);
            
            return retVal;

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public Book GetBook([FromRoute] int id)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books
                                .Include("AuthorBooks").SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
            */

            var book = _context.Books.Where(prod => prod.Id == id).FirstOrDefault();
            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult PutBook([FromRoute] int id, [FromBody] Book product)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            */
            Book retProduct = product;
            IActionResult retResult = null;
            var existingProduct = _context.Books.Where(prod => prod.Id == id).FirstOrDefault();
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                retProduct = existingProduct;
                retResult = Ok(retProduct);
            }
            else
            {
                retResult = NotFound(retProduct);
            }

            return retResult;
        }
           
        // POST: api/Books
        [HttpPost]
        public IActionResult PostBook([FromBody]Book newProduct)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
            */
            Book retProduct = null;
            var existingProduct = _context.Books.Where(prod => prod.Id == newProduct.Id).FirstOrDefault();
            if (existingProduct != null)
            {
                retProduct = existingProduct;
            }
            else
            {
                retProduct = newProduct;
                _context.Books.Add(newProduct);
                _context.SaveChanges();
            }
            return Ok(existingProduct);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}