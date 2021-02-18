using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Server.Data;
using Test.Shared;

namespace Test.Server.Repo.AuthorRepo
{
    public class AuthorRepo
    {
        private readonly AppDbContext _context;

        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Author>>> GetFullAuthors(Guid? id)
        {
            var result = await _context.Author.Select(author => new Author
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                YearBorn = author.YearBorn,
                YearDied = author.YearDied,
                BookAuthors = author.BookAuthors.Select(bookAuthor => new BookAuthor()
                {
                    BookAuthorId = bookAuthor.BookAuthorId,
                    BookId = bookAuthor.BookId
                }).ToList(),
                Books = author.BookAuthors.Select(bookAuthor => bookAuthor.Book).Select(book => new Book
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                }).ToList()
            }).ToListAsync();
            if (id != null)
            {
                result = result.FindAll(author => author.AuthorId == id);
            }
            return result;
        }
    }
}
