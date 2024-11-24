using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.RefreshTokenDomain;

namespace Graduation_Project.Domain.Entity.DoctorDomain
{
    public class DoctorId : ValueObjectId
    {
        protected DoctorId(Guid id) : base(id)
        {
        }

        public static DoctorId Create(Guid id)
        {
            return new(id);
        }

        public static DoctorId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}