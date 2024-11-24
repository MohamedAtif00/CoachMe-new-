using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.UserFeature.AddUser
{
    public record AddUserCommand(Guid userId,string firstName,string secondName, IFormFile image,Gender gender ) :ICommand;
    
    
}
