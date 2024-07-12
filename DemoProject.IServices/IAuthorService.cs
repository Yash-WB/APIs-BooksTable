using DemoProject.DTO;
using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.IServices
{
    public interface IAuthorService
    {
        public Task<GetAuthorDto> GetAuthorByIdAsync(int id);

        public Task<IEnumerable<GetAuthorDto>> GetAllAuthorsAsync();
        public Task<GetAuthorDto> CreateAuthorAsync(CreateAuthorDto authorDto);
        public Task<GetAuthorDto> UpdateAuthorAsync(int id, UpdateAuthorDto authorDto);
        public Task<bool> DeleteAuthorAsync(int id);
    }
}
