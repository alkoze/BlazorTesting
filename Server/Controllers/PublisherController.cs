using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Test.Server.Data;
using Test.Shared;
using Publisher = Test.Shared.Publisher;
namespace Test.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        DataStorage dataStorage = new DataStorage();
        private static List<Publisher> publishers { get; set; } = DataStorage.publishers;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(ILogger<PublisherController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<Publisher> Create(Publisher publisher)
        {
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
            return dataStorage.GetPublisher(id);
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(Guid id)
        {
            publishers.RemoveAll(publisher => publisher.PublisherId == id);
            dataStorage.DeleteBooksWhenPublisherRemoved(id);
         //   bookController.DeleteBooksWhenPublisherRemoved(id);
            return "Deleted";
        }
        [HttpPut]
        public ActionResult<Publisher> Put(Publisher publisher)
        {
            publishers[publishers.FindIndex(p => p.PublisherId.Equals(publisher.PublisherId))] = publisher;
            return publisher;
        }
    }
}
