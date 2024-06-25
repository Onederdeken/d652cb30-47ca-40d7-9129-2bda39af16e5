using job_tasks.Models;

namespace job_tasks.abstractions{
    public interface IFounderRepository{

        public  Task<List<Founder>> GetFoundersAsync();
        public Task CreateAsync(Founder client);
        public Task UpdateAsync(Guid id, String inn, String name,String SecondName, String DadName , DateTime update);
        public Task DeleteAsync(Guid id);

        
    }
}