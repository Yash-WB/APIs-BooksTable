
using DemoProject.DTO;
using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.IServices
{
    public interface IBookService
    {
        public Task<GetBookDto> GetBookByIdAsync(int id);

        public Task<IEnumerable<GetBookDto>> GetAllBooksAsync();
        public Task<GetBookDto> CreateBookAsync(CreateBookDto bookDto);
        public Task<GetBookDto> UpdateBookAsync(int id, UpdateBookDto bookDto);
        public Task<bool> DeleteBookAsync(int id);
    }
}
