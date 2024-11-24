using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;

namespace Graduation_Project.Application.CQRS.PlanFeature.GetPlanByUserId
{
    public record GetPlanByUserIdQuery(Guid userId):IQuery<List<Plan>>;
    
    
}
