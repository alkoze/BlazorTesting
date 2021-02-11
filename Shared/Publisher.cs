using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class Publisher
    {
        public Guid PublisherId { get; set; } = Guid.NewGuid();
        public string PublisherName { get; set; } = default!;

        public int YearFunded { get; set; } = default!;

        public int? YearClosed{ get; set; }
        public List<Book>? PublisherBooks { get; set; } = new List<Book>();
    }
}
