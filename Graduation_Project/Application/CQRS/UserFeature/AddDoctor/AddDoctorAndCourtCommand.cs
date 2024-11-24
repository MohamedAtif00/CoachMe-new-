using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.UserFeature.AddDoctor
{
    public record AddDoctorAndCourtCommand(Guid userId,Guid doctorId):ICommand<bool>;
   
    
}
