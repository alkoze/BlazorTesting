using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Server.Data;
using Test.Server.Repo.PublisherRepo;
using Test.Shared;

namespace Test.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly AppDbContext _context;
        PublisherRepo publisherRepo;

        public PublishersController(AppDbContext context)
        {
            _context = context;
            publisherRepo = new PublisherRepo(context);
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            return await publisherRepo.GetFullPublishers(null);
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(Guid id)
        {
            var publisher = await publisherRepo.GetFullPublishers(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher.Value.FirstOrDefault();
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(Guid id, Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublisher", new { id = publisher.PublisherId }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherExists(Guid id)
        {
            return _context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}
