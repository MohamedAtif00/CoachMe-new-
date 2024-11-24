using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.AddChat
{
    public record AddChatCommand(Guid sender, Guid receiver, string message) :ICommand;
    
    
}
