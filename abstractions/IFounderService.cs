using job_tasks.Models;

namespace job_tasks.abstractions{
    public interface IFounderService
    {
        public Task<List<Founder>> GetAllFoundersAsync();
        public  Task CreateFounderAsync(Founder founder);
        public  Task UpdateFounderAsync(Guid id, String inn, String name,String SecondName, String DadName , DateTime update);
        public Task DeleteFounderAsync(Guid id);
    }
}