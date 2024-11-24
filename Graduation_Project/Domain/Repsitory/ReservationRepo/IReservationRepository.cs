using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.ReservationDomain;

namespace Graduation_Project.Domain.Repsitory.ReservationRepo
{
    public interface IReservationRepository :IGenericRepository<Reservation,ReservationId>
    {
    }
}
