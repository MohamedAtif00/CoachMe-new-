using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;

namespace Graduation_Project.Domain.Entity.MedicalAdvisorDomain
{
    public class MedicalAdvisorId : ValueObjectId
    {
        protected MedicalAdvisorId(Guid id) : base(id)
        {
        }

        public static MedicalAdvisorId Create(Guid id)
        {
            return new(id);
        }

        public static MedicalAdvisorId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}