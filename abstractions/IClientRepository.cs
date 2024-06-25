using job_tasks.Models;

namespace job_tasks.abstractions{
    public interface IClientRepository{

        public  Task<List<Client>> GetClientsAsync();
        public Task CreateAsync(Client client);
        public Task UpdateAsync(Guid id, String INN, String TypeClient);
        public Task DeleteAsync(Guid id);

        
    }
}