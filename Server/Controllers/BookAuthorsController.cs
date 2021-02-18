using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Server.Data;
using Test.Shared;

namespace Test.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookAuthorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BookAuthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthor()
        {
            return await _context.BookAuthor.ToListAsync();
        }

        // GET: api/BookAuthors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthor(Guid id)
        {
            var bookAuthor = await _context.BookAuthor.FindAsync(id);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return bookAuthor;
        }

        // PUT: api/BookAuthors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor(Guid id, BookAuthor bookAuthor)
        {
            if (id != bookAuthor.BookAuthorId)
            {
                return BadRequest();
            }

            _context.Entry(bookAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthor.Add(bookAuthor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.BookAuthorId }, bookAuthor);
        }

        // POST: api/BookAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<BookAuthor>> PostBookAuthor(List<BookAuthor> bookAuthors)
        //{
        //    foreach (var bookAuthor in bookAuthors)
        //    {
        //        _context.BookAuthor.Add(bookAuthor);
        //    }
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetBookAuthor", bookAuthors);
        //}

        // DELETE: api/BookAuthors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthor(Guid id)
        {
            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            _context.BookAuthor.Remove(bookAuthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookAuthorExists(Guid id)
        {
            return _context.BookAuthor.Any(e => e.BookAuthorId == id);
        }
    }
}
