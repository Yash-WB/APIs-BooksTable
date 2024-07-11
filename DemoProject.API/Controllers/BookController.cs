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
        public async Task <IEnumerable<Book>> Get()
        {
            return await _bookService.GetAllBooksAsync();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
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
        public async Task<Book> Post([FromBody] Book book)
        {
            return await _bookService.CreateBookAsync(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<Book> Put(int id, [FromBody] Book book)
        {
            return await _bookService.UpdateBookAsync(id, book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _bookService.DeleteBookAsync(id);
        }
    }
}
