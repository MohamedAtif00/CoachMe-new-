using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesForTrainer
{
    public record GetAllMessagesForTrainerQuery(Guid trainerId):IQuery<List<User>>;
    
    
}
