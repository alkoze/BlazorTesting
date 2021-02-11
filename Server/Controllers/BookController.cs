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
using Test.Server.Data;

namespace Test.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private DataStorage dataStorage = new DataStorage();
        private static List<Book> books { get; set; } = DataStorage.books;
        private readonly ILogger<BookController> _logger;
       // private static ILogger<PublisherController> _publisherLogger;
       // private PublisherController publisherController = new PublisherController(_publisherLogger);
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            Publisher publisher = dataStorage.GetPublisher(book.BookPublisherId);
            book.BookPublisher.PublisherId = publisher.PublisherId;
            book.BookPublisher.PublisherName = publisher.PublisherName;
            books.Add(book);
            dataStorage.AddBookToList(book.BookPublisherId, book);
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
            return books.FindAll(book => book.BookId == id).FirstOrDefault();
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(Guid id)
        {
            Book book = books.FindAll(book => book.BookId == id).FirstOrDefault();
            dataStorage.DeleteBookFromPublisher(book.BookPublisherId, id);
            books.RemoveAll(book => book.BookId == id);
            return "Deleted";
        }
        [HttpPut]
        public ActionResult<Book> Put(Book book)
        {
            dataStorage.UpdateBookInPublisherList(book);
            books[books.FindIndex(b => b.BookId.Equals(book.BookId))] = book;
            return book;
        }
    }
}
