using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;

namespace Graduation_Project.Application.CQRS.PlanFeature.GetAllPlan
{
    public record GetAllPlanQuery(Guid id):IQuery<List<Plan>>;
    
    
}
