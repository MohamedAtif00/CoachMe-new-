using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Infrastructure.DomainConfig.MedicalAdvisorConfig
{
    public class MedicalAdvisorEntityTypeConfiguration : IEntityTypeConfiguration<MedicalAdvisor>
    {
        public void Configure(EntityTypeBuilder<MedicalAdvisor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x => MedicalAdvisorId.Create(x));

        }
    }
}
