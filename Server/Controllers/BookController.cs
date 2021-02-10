using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Shared;
using StateContainer = Test.Shared.StateContainer;
using System.Net.Http;
using System.Net.Http.Json;

namespace Test.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books { get; set; } = new List<Book>();
        private readonly ILogger<BookController> _logger;

        public BookController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        HttpClient httpClient;

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            book.BookId = Guid.NewGuid();
            books.Add(book);
          //  Publisher publisher = await httpClient.GetFromJsonAsync<Publisher>($"publisher/{book.BookPublisherId}");
            return book;
        }
        [HttpGet]
        public IList<Book> Get()
        {
            return books;
        }
        [HttpGet("{id}")]
        public Book Get(Guid id)
        {
            Console.WriteLine("worked");
            Console.WriteLine(id);
            return books.FindAll(book => book.BookId == id).FirstOrDefault();
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(Guid id)
        {
            Console.WriteLine("worked");
            books.RemoveAll(book => book.BookId == id);
            return "Deleted";
        }
        [HttpPut]
        public ActionResult<Book> Put(Book book)
        {
            foreach (var bookToChange in books.Where(b => b.BookId == book.BookId))
            {
                bookToChange.BookName = book.BookName;
                bookToChange.BookPublisherId = book.BookPublisherId;
                bookToChange.BookPublisher = book.BookPublisher;
                bookToChange.BookAuthors = book.BookAuthors;
            }
            return book;
        }

    }
}
