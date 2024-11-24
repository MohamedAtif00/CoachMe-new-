using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetDoctorByUserId
{
    public record GetDoctorByUserIdQuery(Guid userId):IQuery<Doctor>;
    
    
}
