using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Server.Data;
using Test.Shared;

namespace Test.Server.Repo.BookRepo
{
    public class BookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Book>>> GetFullBooks(Guid? id)
        {
            var result = await _context.Books.Select(book => new Book()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                BookPublisherId = book.BookPublisherId,
                BookPublisher = new Publisher
                {
                    PublisherName = book.BookPublisher.PublisherName,
                    YearFunded = book.BookPublisher.YearFunded,
                    YearClosed = book.BookPublisher.YearClosed
                },
                BookAuthors = book.BookAuthors.Select(bookauthor => new BookAuthor() { 
                    BookAuthorId = bookauthor.BookAuthorId,
                    AuthorId = bookauthor.AuthorId
                }).ToList(),
                Authors = book.BookAuthors.Select(bookAuthor => bookAuthor.Author).Select(author => new Author(){
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    YearBorn = author.YearBorn,
                    YearDied = author.YearDied
                }).ToList()
            }).ToListAsync();
            if (id != null)
            {
                result = result.FindAll(book => book.BookId == id);
            }
            return result;
        }
    }
}
