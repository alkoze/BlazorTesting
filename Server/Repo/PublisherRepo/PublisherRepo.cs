using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Server.Data;
using Test.Shared;

namespace Test.Server.Repo.PublisherRepo
{
    public class PublisherRepo
    {
        private readonly AppDbContext _context;

        public PublisherRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Publisher>>> GetFullPublishers(Guid? id)
        {
            var result = await _context.Publishers.Select(publisher => new Publisher {
            PublisherId = publisher.PublisherId,
            PublisherName = publisher.PublisherName,
            YearFunded = publisher.YearFunded,
            YearClosed = publisher.YearClosed,
            PublisherBooks = publisher.PublisherBooks.Select(book => new Book
            {
                BookId = book.BookId,
                BookName = book.BookName
            }).ToList()
            }).ToListAsync();
            if (id != null)
            {
                result = result.FindAll(publisher => publisher.PublisherId == id);
            }
            return result;
        }
    }
}
