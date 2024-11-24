using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.ChatDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesWithTrainee
{
    public record GetAllMessagesWithTraineeQuery(Guid sendId,Guid receiverId):IQuery<List<Chat>>;
    
    
}
