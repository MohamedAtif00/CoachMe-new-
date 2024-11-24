using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetAllDoctors
{
    public record GetAllDoctorsQuery() : IQuery<List<Doctor>>;
    
    
}
