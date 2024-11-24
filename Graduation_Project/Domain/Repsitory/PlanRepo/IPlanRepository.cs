using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Domain.Repsitory.PlanRepo
{
    public interface IPlanRepository : IGenericRepository<Plan, planId>
    {
        Task<List<Plan>> GetAllPlanForTrainer(UserId id);
    }
}
