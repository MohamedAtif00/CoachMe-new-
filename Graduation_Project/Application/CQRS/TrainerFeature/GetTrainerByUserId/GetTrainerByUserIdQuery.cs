using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;

namespace Graduation_Project.Application.CQRS.TrainerFeature.GetTrainerByUserId
{
    public record GetTrainerByUserIdQuery(Guid userId):IQuery<Trainer>;
    
    
}
