
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.DTO
{
    public class AuthorDTO
    {
    }

    public record CreateAuthorDto([Required(ErrorMessage = "Name is required")] string Name, [Required(ErrorMessage = "Email is required")] string Email, [Required(ErrorMessage = "Nationality is required")] string Nationality);
    public record UpdateAuthorDto([Required(ErrorMessage = "Id is required")] int Id, [Required(ErrorMessage = "Name is required")] string Name, [Required(ErrorMessage = "Email is required")] string Email, [Required(ErrorMessage = "Nationality is required")] string Nationality);

    public record GetAuthorDto(int Id, string Name, string Email, string Nationality);
}
