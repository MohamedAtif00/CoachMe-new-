using Graduation_Project.Domain.Entity.ChatDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Infrastructure.DomainConfig.ChatConfig
{
    public class ChatEntityTypeConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => ChatId.Create(x));

            builder.Property(x => x.ReceiverId).HasConversion(x => x.value, x => UserId.Create(x));

            builder.Property(x =>x.SenderId).HasConversion(x =>x.value ,x =>UserId.Create(x));



        }
    }
}
