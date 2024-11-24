using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesForDoctor
{
    public record GetAllMessagesForDoctorQuery(Guid doctorId):IQuery<List<User>>;
    
    
}
