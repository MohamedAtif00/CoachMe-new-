using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.ChatDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Domain.Repsitory.ChatRepo
{
    public interface IChatRepository : IGenericRepository<Chat, ChatId>
    {
        Task<List<Chat>> GetAllMessagesBetweenTrainerAndTrainee(UserId userId, UserId UserId2);
        Task<List<User>> GetAllMessagesForTrainee(UserId sender);
        Task<List<User>> GetAllMessagesForTrainer(UserId trainerId);
    }
}
