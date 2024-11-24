using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.DTOs.Authentication
{
    public record RegisterRequest(string firstName ,string lastName,string email, string password, IFormFile image, Gender gender);
    public record TrainerRegisterRequest(string firstName ,string lastName,string email, string password, IFormFile image, Gender gender,string about   );
}
