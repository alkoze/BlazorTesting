using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class Book
    {
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [StringLength(32, ErrorMessage = "Name length can`t be more than 32.", MinimumLength = 1)]
        public string BookName { get; set; } = default!;

        [Required(ErrorMessage = "Book publisher is required")]
        public Guid? BookPublisherId { get; set; } = null;
        public Publisher? BookPublisher { get; set; }
        
        public ICollection<BookAuthor>? BookAuthors { get; set; }

        public ICollection<Author>? Authors{ get; set; }
    }
}
