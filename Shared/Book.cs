using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class Book
    {
        public Guid BookId { get; set; } = Guid.NewGuid();
        public string BookName { get; set; } = default!;
        public Guid BookPublisherId { get; set; } = default!;
        public Publisher? BookPublisher { get; set; } = new Publisher();
        public ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
