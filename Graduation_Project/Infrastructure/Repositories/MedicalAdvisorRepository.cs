using Graduation_Project.Application.CQRS.MedicalAdvisorFeature.AddMedicalAdvisor;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;
using Graduation_Project.Domain.Repsitory.AddMedicalAdvisorRepo;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.DomainConfig;

namespace Graduation_Project.Infrastructure.Repositories
{
    public class MedicalAdvisorRepository : GenericRepository<MedicalAdvisor, MedicalAdvisorId>, IMedicalAdvisorRepository
    {
        public MedicalAdvisorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
