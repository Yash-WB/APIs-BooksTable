
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
        public Task<Book> GetBookByIdAsync(int id);

        public Task<IEnumerable<Book>> GetAllBooksAsync();
        public Task<Book> CreateBookAsync(Book book);
        public Task<Book> UpdateBookAsync(int id, Book book);
        public Task<bool> DeleteBookAsync(int id);
    }
}
