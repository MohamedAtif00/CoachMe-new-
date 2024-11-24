using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.PlanFeature.AddPlan
{
    public record AddPlanCommand(string name,int duration, string focus, int sessions, decimal price,Guid trainerId) :ICommand;
    
    
}
