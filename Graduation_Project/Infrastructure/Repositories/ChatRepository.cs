using Graduation_Project.Domain.Entity.ChatDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using Graduation_Project.Domain.Repsitory.ChatRepo;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Infrastructure.Repositories
{
    public class ChatRepository : GenericRepository<Chat, ChatId>, IChatRepository
    {
        public ChatRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllMessagesForTrainer(UserId receiver)
        {
            return await _context.chats
                .Where(chat => chat.ReceiverId == receiver)
                .SelectMany(chat => _context.users.Where(user => user.Id == chat.SenderId))
                .Distinct()
                .ToListAsync();

        }

        public async Task<List<User>> GetAllMessagesForTrainee(UserId sender)
        {
            return await _context.chats
                .Where(chat => chat.SenderId == sender)
                .SelectMany(chat => _context.users.Where(user => user.Id == chat.ReceiverId))
                .Distinct()
                .ToListAsync();

        }

        public async Task<List<Chat>> GetAllMessagesBetweenTrainerAndTrainee(UserId userId,UserId UserId2)
        {
            return await _context.chats.Where((x => (x.SenderId == userId && x.ReceiverId == UserId2) ||(x.SenderId == UserId2 && x.ReceiverId == userId))).ToListAsync();
        }

    }
}
