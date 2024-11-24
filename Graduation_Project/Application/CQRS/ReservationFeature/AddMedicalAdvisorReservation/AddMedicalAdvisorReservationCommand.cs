using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.ReservationFeature.AddMedicalAdvisorReservation
{
    public record AddMedicalAdvisorReservationCommand(Guid doctorId, Guid patient, Guid planId) :ICommand;
    
    
}
