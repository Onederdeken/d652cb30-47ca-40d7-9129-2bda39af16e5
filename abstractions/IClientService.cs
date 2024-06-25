using job_tasks.Models;

namespace job_tasks.abstractions{
    public interface IClientService{
        public  Task<List<Client>> GetAllClientsAsync();
        public  Task CreateClientAsync(Client client);
        public  Task UpdateClientAsync(Guid id, String INN, String TypeClient);
        public  Task DeleteClientAsync(Guid id);
    }
}