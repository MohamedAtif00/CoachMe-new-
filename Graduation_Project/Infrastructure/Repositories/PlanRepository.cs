using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using Graduation_Project.Domain.Repsitory.PlanRepo;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Infrastructure.Repositories
{
    public class PlanRepository : GenericRepository<Plan, planId>, IPlanRepository
    {
        public PlanRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Plan>> GetAllPlanForTrainer(UserId id)
        {
            return await _context.plans.Where(x => x.TrainerId == id).ToListAsync();
        }
    }
}
