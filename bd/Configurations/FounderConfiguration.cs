using job_tasks.bd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace job_tasks.bd.Configurations{
    public class FounderConfiguration : IEntityTypeConfiguration<FounderEntity>
    {
        public void Configure(EntityTypeBuilder<FounderEntity> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(e=>e.Client)
                .WithMany(e=>e.Founders)
                .HasForeignKey(e=>e.ClientId);
        }
    }
}