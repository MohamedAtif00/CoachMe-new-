using Graduation_Project.Domain.Abstraction;

namespace Graduation_Project.Domain.Entity.ChatDomain
{
    public class ChatId : ValueObjectId
    {
        protected ChatId(Guid id) : base(id)
        {
        }

        public static ChatId Create(Guid id)
        { 
            return new ChatId(id);
        }

        public static ChatId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

    }
}