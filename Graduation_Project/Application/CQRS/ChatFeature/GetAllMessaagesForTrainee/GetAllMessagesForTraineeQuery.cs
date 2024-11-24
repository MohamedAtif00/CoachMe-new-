using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessaagesForTrainee
{
    public record GetAllMessagesForTraineeQuery(Guid userId):IQuery<List<User>>;
    
    
}
