using job_tasks.abstractions;
using job_tasks.Models;

namespace job_tasks.Service{

    public class ClientService:IClientService{
        private readonly IClientRepository _ClientRepository;

        public ClientService(IClientRepository clientRepository){
            _ClientRepository = clientRepository;
        }
        public async Task<List<Client>> GetAllClientsAsync(){
            return await _ClientRepository.GetClientsAsync();
        }
        public async Task CreateClientAsync(Client client){
            await _ClientRepository.CreateAsync(client);
        }
        public async Task UpdateClientAsync(Guid id, String INN, String TypeClient){
            await _ClientRepository.UpdateAsync(id,INN,TypeClient);
        }
        public async Task DeleteClientAsync(Guid id){
            await _ClientRepository.DeleteAsync(id);
        }
    }
}