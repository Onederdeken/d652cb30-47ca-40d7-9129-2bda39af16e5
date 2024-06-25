using job_tasks.bd.Connections;
using job_tasks.bd.Entities;
using job_tasks.Models;
using Microsoft.EntityFrameworkCore;
using job_tasks.abstractions;
using Microsoft.AspNetCore.Mvc;
namespace job_tasks.bd.Repositories{

    public class ClientRepository:IClientRepository{
        protected readonly BdContext  _Context;
        public ClientRepository(BdContext Context){
            this._Context=Context;
        }

        public async Task<List<Client>> GetClientsAsync(){

            var ClientEntity =  await _Context.clients.Include(p=>p.Founders)
                                .ToListAsync();
            List<Client> clients = new List<Client>();
            foreach(var item in ClientEntity){
                List<Founder> founders = new List<Founder>();
                var client = Client.Create(item.Id,item.INN,item.TypeClient,item.DateCreate,item.DateUpdate).client;
                
                foreach (var founder in item.Founders)
                {

                    founders.Add(Founder.createFounder(founder.Id, founder.INN, founder.PersonName, founder.PersonSecondName, founder.PersonDadName, founder.DateCreate, founder.DateUpdate,client.Id ,client).founder);
                }
                client.Founders = founders;
                clients.Add(client);
            }
           
            return clients;
        }
        public async Task  CreateAsync(Client client){
            var ClientEntity = new ClientEntity{
                Id=client.Id,
                INN=client.INN,
                TypeClient=client.TypeClient,
                DateCreate = client.DateCreate,
                DateUpdate = client.DateUpdate
            };
            await _Context.clients.AddAsync(ClientEntity);
            await _Context.SaveChangesAsync();

        }
        public async Task UpdateAsync(Guid id, String INN, String TypeClient){
            await _Context.clients
            .Where(p=>p.Id == id)
            .ExecuteUpdateAsync(s=>s
            .SetProperty(b=>b.INN , b=>INN)
            .SetProperty(b=>b.TypeClient,b=>TypeClient)
            .SetProperty(b=>b.DateUpdate,DateTime.Now)
            );
            await _Context.SaveChangesAsync();

        }
        public async Task DeleteAsync(Guid id){
           
            _Context.clients.Remove(await _Context.clients.FindAsync(id));
            await _Context.SaveChangesAsync();
        }


    }
}