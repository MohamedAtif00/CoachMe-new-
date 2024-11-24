using Graduation_Project.Domain.Abstraction;

namespace Graduation_Project.Domain.Entity.ReservationDomain
{
    public class ReservationId : ValueObjectId
    {
        protected ReservationId(Guid id) : base(id)
        {
        }

        public static ReservationId Create(Guid id)
        {
            return new(id);
        }

        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}