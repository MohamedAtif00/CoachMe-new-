using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.MedicalAdvisorFeature.AddMedicalAdvisor
{
    public record AddMedicalAdvisorCommand(Guid id,string username, string about, IFormFile image, string email) :ICommand;
    
    
}
