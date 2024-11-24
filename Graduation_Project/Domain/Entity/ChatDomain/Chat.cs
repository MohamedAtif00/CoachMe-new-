using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Domain.Entity.ChatDomain
{
    public class Chat : Entity<ChatId>
    {
        public Chat(ChatId id, UserId senderId, UserId receiverId, string message) : base(id)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Message = message;
        }

        public UserId SenderId { get; set; }
        public UserId ReceiverId  { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public static Chat Create(UserId senderId, UserId receiverId, string message)
        {
            return new(ChatId.CreateUnique(),  senderId,  receiverId,  message);
        }




    }
}
