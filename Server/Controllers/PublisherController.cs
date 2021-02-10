using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Publisher = Test.Shared.Publisher;
namespace Test.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private static List<Publisher> publishers { get; set; } = new List<Publisher>();
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(ILogger<PublisherController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<Publisher> Create(Publisher publisher)
        {
            publisher.PublisherId = Guid.NewGuid();
            publishers.Add(publisher);
            return publisher;
        }
        [HttpGet]
        public IList<Publisher> Get()
        {
            return publishers;
        }
        [HttpGet("{id}")]
        public Publisher Get(Guid id)
        {
            return publishers.FindAll(publisher => publisher.PublisherId == id).FirstOrDefault();
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(Guid id)
        {
            publishers.RemoveAll(publisher => publisher.PublisherId == id);
            return "Deleted";
        }
        [HttpPut]
        public ActionResult<Publisher> Put(Publisher publisher)
        {
            foreach(var publisherToChange in publishers.Where(p=> p.PublisherId == publisher.PublisherId))
            {
                publisherToChange.PublisherName = publisher.PublisherName;
                publisherToChange.YearFunded = publisher.YearFunded;
                publisherToChange.YearClosed = publisher.YearClosed;
                publisherToChange.PublisherBooks = publisher.PublisherBooks;
            }
            return publisher;
        }
    }
}
