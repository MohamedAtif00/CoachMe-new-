using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.ReservationDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Infrastructure.DomainConfig.ReservationConfig
{
    public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x =>x.Id);

            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>ReservationId.Create(x));
            builder.Property(x => x.TrainerId).HasConversion(x =>x.value,x =>TrainerId.Create(x));
            builder.Property(x => x.Trainee).HasConversion(x =>x.value,x =>UserId.Create(x));
            builder.Property(x =>x.PlanId).HasConversion(x =>x.value,x =>planId.Create(x));
        }
    }
}
