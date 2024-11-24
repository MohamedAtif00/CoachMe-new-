using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetAllRating
{
    public record GetAllRatingQuery(Guid doctorId):IQuery<List<DoctorRating>>;
    
    
}
