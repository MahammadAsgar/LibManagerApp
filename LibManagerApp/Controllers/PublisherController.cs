using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public PublisherService _publisherService { get; set; }
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody]PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublisher()
        {
            var publishers=_publisherService.GetPublishers();
            return Ok(publishers);
        }
    }
}
