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
        public Guid? PublisherId { get; set; }
        public String PublisherName { get; set; } = default!;

        public int YearFunded { get; set; } = default!;

        public int? YearClosed{ get; set; }

        public ICollection<Book>? PublisherBooks { get; set; }
    }
}
