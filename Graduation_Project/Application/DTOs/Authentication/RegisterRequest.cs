using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.DTOs.Authentication
{
    public record RegisterRequest(string firstName ,string lastName,string email, string password, IFormFile image, Gender gender);
    public record DoctorRegisterRequest(string firstName ,string lastName,string email, string password, IFormFile image, Gender gender,string about   );
}
