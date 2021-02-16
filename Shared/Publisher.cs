using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class Publisher
    {
        public Guid PublisherId { get; set; }

        [Required(ErrorMessage = "Publisher name is required")]
        [StringLength(32, ErrorMessage ="Name length can`t be more than 32.", MinimumLength = 1)]
        public string PublisherName { get; set; } = default!;

        [Required(ErrorMessage = "Year of creation is required")]
        public int YearFunded { get; set; } = default!;

        public int? YearClosed { get; set; } = null;
        public ICollection<Book> PublisherBooks { get; set; } = new List<Book>();
    }
}
