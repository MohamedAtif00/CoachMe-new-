using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.DoctorFeature.DeleteDoctor
{
    public record DeleteDoctorCommand(Guid id):ICommand;
    
    
}
