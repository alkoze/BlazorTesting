using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class BookAuthor
    {
        public Guid  BookAuthorId{ get; set; }
        [Required]
        public Guid AuthorId{ get; set; }
        [Required]
        public Guid BookId { get; set; }

        public Author? Author { get; set; }

        public Book? Book { get; set; }
    }
}
