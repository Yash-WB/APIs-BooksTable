using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.DTO
{
    public class PublisherDTO
    {
    }

    public record CreatePublisherDto([Required(ErrorMessage = "Name is required")] string Name, [Required(ErrorMessage = "Address is required")] string Address);
    public record UpdatePublisherDto([Required(ErrorMessage = "Id is required")] int Id, [Required(ErrorMessage = "Name is required")] string Name, [Required(ErrorMessage = "Address is required")] string Address);

    public record GetPublisherDto(int Id, string Name, string Address);
}
