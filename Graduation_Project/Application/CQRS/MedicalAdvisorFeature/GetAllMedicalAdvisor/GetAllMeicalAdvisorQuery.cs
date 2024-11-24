using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;

namespace Graduation_Project.Application.CQRS.MedicalAdvisorFeature.GetAllMedicalAdvisor
{
    public record GetAllMeicalAdvisorQuery():IQuery<List<MedicalAdvisor>>;
    
    
}
