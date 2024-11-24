using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.TrainerFeature.UpdateTrainer
{
    public record UpdateTrainerCommand(Guid id,string username, string email, IFormFile image) :ICommand;
    
    
}
