using job_tasks.abstractions;
using job_tasks.Models;

namespace job_tasks.Service{

    public class FounderService:IFounderService{
        private readonly IFounderRepository _FounderRepository;

        public FounderService(IFounderRepository FounderRepository){
            _FounderRepository = FounderRepository;
        }
        public async Task<List<Founder>> GetAllFoundersAsync(){
            return await _FounderRepository.GetFoundersAsync();
        }
        public async Task CreateFounderAsync(Founder founder){
            await _FounderRepository.CreateAsync(founder);
        }
        public async Task UpdateFounderAsync(Guid id, String inn, String name,String SecondName, String DadName , DateTime update){
           await _FounderRepository.UpdateAsync(id,inn,name,SecondName,DadName,update);
        }
        public async Task DeleteFounderAsync(Guid id){
            await _FounderRepository.DeleteAsync(id);
        }
    }
}