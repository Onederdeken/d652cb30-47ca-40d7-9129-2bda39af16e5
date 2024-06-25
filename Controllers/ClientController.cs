


using job_tasks.abstractions;
using job_tasks.Contracts;
using job_tasks.Models;
using Microsoft.AspNetCore.Mvc;

namespace job_tasks.Controllers{
    [ApiController]
    [Route("[controller]/")]
    public class ClientController:Controller{
        protected readonly IClientService _ClientService;
        public ClientController(IClientService clientService){
            _ClientService = clientService;
        }

        [HttpGet]
        [Route("API/GetClients")] 
        public async Task<ActionResult<List<ClientResponse>>> GetClientsAsync(){
            var Clients = await _ClientService.GetAllClientsAsync();
            var ClientResponses = Clients.Select(p=> new ClientResponse(
                p.Id,
                p.INN,
                p.TypeClient,
                p.DateCreate.ToString("g"),
                p.DateUpdate.ToString("g"),
                p.Founders.Select(
                    p=>new FoundersForClientResponse(
                        p.Id,
                        p.INN,
                        p.PersonName,
                        p.PersonSecondName,
                        p.PersonDadName,
                        p.DateCreate.ToString("g"),
                        p.DateUpdate.ToString("g")
                    )
                ).ToList()
            )
        );
            return Ok(ClientResponses);
        }
        [HttpPost]
       [Route("API/CreateClient")] 
        public async Task<ActionResult> CreateClientAsync([FromBody] ClientRequest request){
            var (client, error) = Client.Create(
                Guid.NewGuid(),
                request.INN,
                request.Type,
                DateTime.Now,
                DateTime.Now
            );
            if(!string.IsNullOrEmpty(error)){
                return BadRequest(error);
            }
            await _ClientService.CreateClientAsync(client);
            return Ok(200);
        }
        [HttpPut]
        [Route("API/UpdateClient/{Clientid:guid}")] 
        public async Task<ActionResult> UpdateClientAsync(Guid Clientid,[FromBody] ClientRequest request){

            var (client, error) = Client.Create(
                Clientid,
                request.INN,
                request.Type
            );
            if(!String.IsNullOrEmpty(error)){
                return BadRequest();
            }
            await _ClientService.UpdateClientAsync(Clientid, client.INN, client.TypeClient);
            return Ok(200);
        }
        [HttpDelete]
        [Route("API/DeleteClient/{Clientid:guid}")] 
        public async Task<ActionResult> DeleteClientAsync(Guid Clientid){
            await _ClientService.DeleteClientAsync(Clientid);
            return Ok(200);
        }

        

    }
}