using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.ReservationDomain;

namespace Graduation_Project.Application.CQRS.ReservationFeature.GetAllReservation
{
    public record GetAllReservationIQuery():IQuery<List<Reservation>>;
    
    
}
