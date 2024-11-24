using Graduation_Project.Domain.Abstraction;

namespace Graduation_Project.Domain.Entity.DoctorDomain
{
    public class DoctorRatingId : ValueObjectId
    {
        protected DoctorRatingId(Guid id) : base(id)
        {
        }

        public static DoctorRatingId Create(Guid id)
        {
            return new(id);
        }
        public static DoctorRatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}