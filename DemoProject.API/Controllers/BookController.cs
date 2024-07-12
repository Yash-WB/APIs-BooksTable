using DemoProject.DTO;
using DemoProject.IServices;
using DemoProject.Model;
using DemoProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task <IEnumerable<GetBookDto>> Get()
        {
            return await _bookService.GetAllBooksAsync();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<GetBookDto> Get(int id)
        {

            try
            {
                return await _bookService.GetBookByIdAsync(id);
            }
            catch (Exception e)

            {
                Console.WriteLine(e.Message);

                throw;
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<GetBookDto> Post([FromBody] CreateBookDto bookDto)
        {
            return await _bookService.CreateBookAsync(bookDto);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<GetBookDto> Put(int id, [FromBody] UpdateBookDto bookDto)
        {
            return await _bookService.UpdateBookAsync(id, bookDto);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _bookService.DeleteBookAsync(id);
        }
    }
}
