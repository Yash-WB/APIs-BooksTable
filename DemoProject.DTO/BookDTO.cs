using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.DTO
{
    public class BookDTO
    {
    }

    public record CreateBookDto([Required(ErrorMessage = "Name is required")] string Name, [Required(ErrorMessage = "Description is required")] string Description, [Required(ErrorMessage = "AuthorId is required")] int AuthorId, [Required(ErrorMessage = "PublisherId is required")] int PublisherId);
    public record UpdateBookDto([Required(ErrorMessage = "Id is required")] int Id, [Required(ErrorMessage = "Name is required")] string Name, [Required(ErrorMessage = "Description is required")] string Description, [Required(ErrorMessage = "AuthorId is required")] int AuthorId, [Required(ErrorMessage = "PublisherId is required")] int PublisherId);

    public record GetBookDto(int Id, string Name, string Description, int AuthorId, int PublisherId);
}
