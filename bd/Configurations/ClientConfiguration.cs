using job_tasks.bd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace job_tasks.bd.Configurations{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasMany(e=>e.Founders)
                .WithOne(e=>e.Client)
                .HasForeignKey(e=>e.ClientId);
        }
    }
}