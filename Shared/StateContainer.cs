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

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
