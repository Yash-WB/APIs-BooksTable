using DemoProject.DTO;
using DemoProject.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        // GET: api/<PublisherController>
        [HttpGet]
        public async Task<IEnumerable<GetPublisherDto>> Get()
        {
            return await _publisherService.GetAllPublishersAsync();
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public async Task<GetPublisherDto> Get(int id)
        {
            return await _publisherService.GetPublisherByIdAsync(id);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public async Task<GetPublisherDto> Post([FromBody] CreatePublisherDto publisherDto)
        {
            return await _publisherService.CreatePublisherAsync(publisherDto);
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public async Task<GetPublisherDto> Put(int id, [FromBody] UpdatePublisherDto publisherDto)
        {
            return await _publisherService.UpdatePublisherAsync(id, publisherDto);
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return _publisherService.DeletePublisherAsync(id);
        }
    }
}
