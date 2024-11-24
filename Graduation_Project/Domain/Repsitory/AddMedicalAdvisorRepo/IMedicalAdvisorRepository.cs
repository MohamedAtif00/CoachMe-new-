using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;

namespace Graduation_Project.Domain.Repsitory.AddMedicalAdvisorRepo
{
    public interface IMedicalAdvisorRepository :IGenericRepository<MedicalAdvisor,MedicalAdvisorId>
    {
    }
}
