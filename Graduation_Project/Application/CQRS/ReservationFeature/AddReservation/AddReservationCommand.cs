using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.ReservationFeature.AddReservation
{
    public record AddReservationCommand(Guid trainerId, Guid trainee, Guid planId) :ICommand;
    
    
}
