using job_tasks.bd.Configurations;
using job_tasks.bd.Entities;
using Microsoft.EntityFrameworkCore;

namespace job_tasks.bd.Connections{
    //
    public class BdContext:DbContext{
        public BdContext(DbContextOptions<BdContext> options):base(options){
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FounderConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ClientEntity> clients{get;set;}=null!;
        public DbSet<FounderEntity> founders{get;set;}=null!;

    }
}