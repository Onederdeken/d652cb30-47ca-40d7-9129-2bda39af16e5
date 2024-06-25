using job_tasks.bd.Connections;
using job_tasks.bd.Entities;
using job_tasks.Models;
using Microsoft.EntityFrameworkCore;
using job_tasks.abstractions;
using Microsoft.AspNetCore.Mvc;
namespace job_tasks.bd.Repositories{
    public class FounderRepository:IFounderRepository{
        protected readonly BdContext _Context;
        public FounderRepository(BdContext Context){
            _Context = Context;
        }
        public async Task<List<Founder>> GetFoundersAsync(){
            var FounderEntity =  await _Context.founders.Include(p=>p.Client)
                                .AsNoTracking()
                                .ToListAsync();
            List<Founder> founders = new List<Founder>();
            foreach(var founder in FounderEntity){
                Client client = Client.Create
                (
                    founder.ClientId,
                    founder.Client.INN,
                    founder.Client.TypeClient,
                    founder.Client.DateCreate,
                    founder.Client.DateUpdate
                ).client;
                founders.Add(
                    Founder.createFounder(
                        founder.Id,
                        founder.INN,
                        founder.PersonName,
                        founder.PersonSecondName,
                        founder.PersonDadName,
                        founder.DateCreate,
                        founder.DateUpdate,
                        client.Id,
                        client
                    ).founder);
            }
            return founders;
        }
        public async Task  CreateAsync(Founder founder){
            
            var FounderEntity = new FounderEntity{
                Id=founder.Id,
                INN=founder.INN,
                PersonName = founder.PersonName,
                PersonSecondName = founder.PersonSecondName,
                PersonDadName = founder.PersonDadName,
                ClientId = founder.ClientId,
                Client = await _Context.clients.FindAsync(founder.ClientId),
                DateCreate = founder.DateCreate,
                DateUpdate = founder.DateUpdate
            };
            await _Context.founders.AddAsync(FounderEntity);
            await _Context.SaveChangesAsync();

        }
        public async Task UpdateAsync(Guid id, String inn, String name,String SecondName, String DadName , DateTime update){
            await _Context.founders
            .Where(p=>p.Id == id)
            .ExecuteUpdateAsync(s=>s
            .SetProperty(b=>b.INN , b=>inn)
            .SetProperty(b=>b.PersonName, b=>name)
            .SetProperty(b=>b.PersonSecondName, b=>SecondName)
            .SetProperty(b=>b.PersonDadName, b=>DadName)
            .SetProperty(b=>b.DateUpdate,b=>update)
            );
            await _Context.SaveChangesAsync();

        }
        public async Task DeleteAsync(Guid id){
            _Context.founders.Remove(await _Context.founders.FindAsync(id));
            await _Context.SaveChangesAsync();
        }
    }

}