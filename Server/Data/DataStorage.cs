using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Shared;

namespace Test.Server.Data
{
    public class DataStorage
    {
        public static List<Book> books { get; set; } = new List<Book>();
        public static List<Publisher> publishers { get; set; } = new List<Publisher>();

        public Publisher GetPublisher(Guid id)
        {
            return publishers.FindAll(publisher => publisher.PublisherId == id).FirstOrDefault();
        }

        public void AddBookToList(Guid id, Book book)
        {
            publishers.FindAll(publisher => publisher.PublisherId == id).FirstOrDefault().PublisherBooks.Add(book);
        }

       public void DeleteBookFromPublisher(Guid publisherId, Guid bookId)
        {
        //    publishers.FindAll(publisher => publisher.PublisherId == publisherId).FirstOrDefault().
        //        PublisherBooks.RemoveAll(book => book.BookId == bookId);
        }

        public void DeleteBooksWhenPublisherRemoved(Guid publisherId)
        {
            books.RemoveAll(book => book.BookPublisherId == publisherId);
        }

        public void UpdateBookInPublisherList(Book book)
        {
            Book currentBook = books.FindAll(b => b.BookId.Equals(book.BookId)).FirstOrDefault();
            if (!currentBook.BookPublisherId.Equals(book.BookPublisherId))
            {
                //DeleteBookFromPublisher(currentBook.BookPublisherId, currentBook.BookId);
                //AddBookToList(book.BookPublisherId, book);
            }
            else
            {
                //List<Book> publisherBooks = publishers.FindAll(publisher => publisher.PublisherId == book.BookPublisherId).FirstOrDefault().PublisherBooks;
                //publishers.FindAll(publisher => publisher.PublisherId == book.BookPublisherId).FirstOrDefault().
                //    PublisherBooks[publisherBooks.FindIndex(b => b.BookId.Equals(book.BookId))] = book;
            }
        }
    }
}
