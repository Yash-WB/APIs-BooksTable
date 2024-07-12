using DemoProject.DTO;
using DemoProject.IServices;
using DemoProject.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task <IEnumerable<GetAuthorDto>> Get()
        {
            return await _authorService.GetAllAuthorsAsync();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task <GetAuthorDto> Get(int id)
        {
            return await _authorService.GetAuthorByIdAsync(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<GetAuthorDto> Post([FromBody] CreateAuthorDto authorDto)
        {
            return await _authorService.CreateAuthorAsync(authorDto);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<GetAuthorDto> Put(int id, [FromBody] UpdateAuthorDto authorDto)
        {
            return await _authorService.UpdateAuthorAsync(id, authorDto);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _authorService.DeleteAuthorAsync(id);
        }
    }
}
