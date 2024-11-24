using Graduation_Project.Domain.Entity.DoctorDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Infrastructure.DomainConfig.DoctorConfig
{
    public class DoctorRatingConfiguration : IEntityTypeConfiguration<DoctorRating>
    {
        public void Configure(EntityTypeBuilder<DoctorRating> builder)
        {
            builder.HasKey(x =>x.Id);

            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>DoctorRatingId.Create(x));
            builder.Property(x => x.DoctorId).HasConversion(x =>x.value,x =>DoctorId.Create(x));
        }
    }
}
