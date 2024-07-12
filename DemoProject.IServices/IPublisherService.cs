using DemoProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.IServices
{
    public interface IPublisherService
    {
        public Task<GetPublisherDto> GetPublisherByIdAsync(int id);

        public Task<IEnumerable<GetPublisherDto>> GetAllPublishersAsync();
        public Task<GetPublisherDto> CreatePublisherAsync(CreatePublisherDto publisherDto);
        public Task<GetPublisherDto> UpdatePublisherAsync(int id, UpdatePublisherDto publisherDto);
        public Task<bool> DeletePublisherAsync(int id);
    }
}
