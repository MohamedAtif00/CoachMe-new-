using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.AddRating
{
    public record AddRatingCommand(Guid doctorId,Rating  Rating,string username):ICommand;
    
    
}
