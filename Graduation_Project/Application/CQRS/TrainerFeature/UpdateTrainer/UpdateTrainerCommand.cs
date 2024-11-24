using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.DoctorFeature.UpdateDoctor
{
    public record UpdateDoctorCommand(Guid id,string username, string email, IFormFile image) :ICommand;
    
    
}
