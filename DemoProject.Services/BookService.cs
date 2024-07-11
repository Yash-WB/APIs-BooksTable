using DemoProject.IRepositories;
using DemoProject.IServices;
using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Services
{

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public async Task<Book> CreateBookAsync(Book book)
        {
            return await _bookRepository.CreateAsync(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var isFound = await _bookRepository.GetByIdAsync(id);

            if(isFound != null)
            {
                return await _bookRepository.DeleteAsync(isFound);
            }
            return false;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            var oldBook = await _bookRepository.GetByIdAsync(id);

            if(oldBook != null)
            {
                oldBook.Author = book.Author;
                oldBook.Name = book.Name;
                oldBook.Description = book.Description;

                await _bookRepository.UpdateAsync(oldBook);

                return oldBook;
            }
            else
            {
                return null;
            }
        }
    }
}
