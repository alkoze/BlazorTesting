using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class StateContainer
    {
        public string Property { get; set; } = "Initial value from StateContainer";
        public IList<string> ListString { get; set; } = new List<String>();

        public List<Publisher> publishers { get; set; } = new List<Publisher>();

        public List<Book> books { get; set; } = new List<Book>();

        public event Action OnChange;

        public void SetProperty(string value)
        {
            Property = value;
            NotifyStateChanged();
        }

        public void AddBook(Book book)
        {
            if (books == null)
            {
                books = new List<Book>();
            }
            books.Add(book);
        }

        public void RemoveBook(Guid? id)
        {
            if (books == null)
            {
                books = new List<Book>();
            }
            books.RemoveAll(book => book.BookId == id);
        }

        public void AddPublisher(Publisher publisher)
        {
            if(publishers == null)
            {
                publishers = new List<Publisher>();
            }
            publishers.Add(publisher);
        }

        public void RemovePublisher(Guid? id)
        {
            if (publishers == null)
            {
                publishers = new List<Publisher>();
            }
            publishers.RemoveAll(publisher => publisher.PublisherId == id);
        }

        public void AddString(string text)
        {
            if (ListString == null)
            {
                ListString = new List<string>();
            }
            ListString.Add(text);
            NotifyStateChanged();
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
