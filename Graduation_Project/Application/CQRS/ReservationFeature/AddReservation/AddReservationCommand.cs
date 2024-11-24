using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.ReservationFeature.AddReservation
{
    public record AddReservationCommand(Guid doctorId, Guid patient, Guid planId) :ICommand;
    
    
}
