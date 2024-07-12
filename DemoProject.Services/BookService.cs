using DemoProject.DTO;
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


        public async Task<GetBookDto> CreateBookAsync(CreateBookDto bookDto)
        {
            var book = await _bookRepository.CreateAsync(new Book() { AuthorId = bookDto.AuthorId, PublisherId = bookDto.PublisherId ,Description = bookDto.Description, Name = bookDto.Name});
            return new GetBookDto(book.Id, book.Name, book.Description, book.AuthorId, book.PublisherId);
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

        public async Task<IEnumerable<GetBookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            var bookDto = books.Select(book => new GetBookDto(book.Id, book.Name, book.Description, book.AuthorId, book.PublisherId));

            return bookDto;
        }

        public async Task<GetBookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return new GetBookDto(book.Id, book.Name, book.Description, book.AuthorId, book.PublisherId);

        }

        public async Task<GetBookDto> UpdateBookAsync(int id, UpdateBookDto bookDto)
        {
            var oldBook = await _bookRepository.GetByIdAsync(id);

            if(oldBook != null)
            {
                oldBook.AuthorId = bookDto.AuthorId;
                oldBook.PublisherId = bookDto.PublisherId;
                oldBook.Name = bookDto.Name;
                oldBook.Description = bookDto.Description;

                await _bookRepository.UpdateAsync(oldBook);

                return new GetBookDto(oldBook.Id, oldBook.Name, oldBook.Description, oldBook.AuthorId, oldBook.PublisherId);
            }
            else
            {
                return null;
            }
        }
    }
}
