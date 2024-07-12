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
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public async Task<GetPublisherDto> CreatePublisherAsync(CreatePublisherDto publisherDto)
        { 
            var publisher = await _publisherRepository.CreateAsync(new Publisher() {Name = publisherDto.Name , Address = publisherDto.Address });
            return new GetPublisherDto(publisher.Id, publisher.Name, publisher.Address);
        }

        public async Task<bool> DeletePublisherAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);

            if(publisher != null)
            {
                await _publisherRepository.DeleteAsync(publisher);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<GetPublisherDto>> GetAllPublishersAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();

            var publisherDto = publishers.Select(publisher => new GetPublisherDto(publisher.Id, publisher.Name, publisher.Address));

            return publisherDto;
        }

        public async Task<GetPublisherDto> GetPublisherByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);

            return new GetPublisherDto(publisher.Id, publisher.Name, publisher.Address);
        }

        public async Task<GetPublisherDto> UpdatePublisherAsync(int id, UpdatePublisherDto publisherDto)
        {
            var oldPublisher = await _publisherRepository.GetByIdAsync(id); 

            if(oldPublisher != null)
            {
                oldPublisher.Name = publisherDto.Name;
                oldPublisher.Address = publisherDto.Address;

                await _publisherRepository.UpdateAsync(oldPublisher);

                return new GetPublisherDto(oldPublisher.Id, oldPublisher.Name, oldPublisher.Address);
            }
            else
            {
                return null;
            }
        }
    }
}
