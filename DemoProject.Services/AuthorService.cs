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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<GetAuthorDto> CreateAuthorAsync(CreateAuthorDto authorDto)
        {
            var author = await _authorRepository.CreateAsync(new Author() { Name = authorDto.Name, Email = authorDto.Email, Nationality = authorDto.Nationality });
            return new GetAuthorDto(author.Id, author.Name, author.Email, author.Nationality);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if(author != null)
            {
                return await _authorRepository.DeleteAsync(author);
            }
            return false;
        }

        public async Task<IEnumerable<GetAuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            var authorDto = authors.Select(author => new GetAuthorDto(author.Id, author.Name, author.Email, author.Nationality));

            return authorDto;
        }

        public async Task<GetAuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            return new GetAuthorDto(author.Id, author.Name, author.Nationality, author.Email);
        }

        public async Task<GetAuthorDto> UpdateAuthorAsync(int id, UpdateAuthorDto authorDto)
        {
            var oldAuthor = await _authorRepository.GetByIdAsync(id);

            if(oldAuthor != null)
            {
                oldAuthor.Email = authorDto.Email;
                oldAuthor.Nationality = authorDto.Nationality;
                oldAuthor.Name = authorDto.Name;

                await _authorRepository.UpdateAsync(oldAuthor);

                return new GetAuthorDto(oldAuthor.Id, oldAuthor.Name, oldAuthor.Nationality, oldAuthor.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
