using Graduation_Project.Application.Abstraction;

namespace Graduation_Project.Application.CQRS.TrainerFeature.AddTrainer
{
    public record AddTrainerCommand(Guid userId,string username, string email,IFormFile image,string about) : ICommand;
    
    
}
