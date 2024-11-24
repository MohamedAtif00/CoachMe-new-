using Graduation_Project.Domain.Abstraction;

namespace Graduation_Project.Domain.Entity.PlanDomain
{
    public class planId : ValueObjectId
    {
        protected planId(Guid id) : base(id)
        {
        }

        public static planId Create(Guid id)
        {
            return new(id);
        }

        public static planId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}