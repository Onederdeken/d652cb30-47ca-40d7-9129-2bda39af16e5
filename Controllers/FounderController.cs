


using job_tasks.abstractions;
using job_tasks.Contracts;
using job_tasks.Models;
using Microsoft.AspNetCore.Mvc;

namespace job_tasks.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class FounderController:ControllerBase{
        private readonly IFounderService _FounderService;
        public FounderController(IFounderService founderService){
            _FounderService = founderService;
        }
        [HttpGet]
        [Route("API/GetFounders")]
        public async Task<ActionResult<List<FounderResponse>>> GetFoundersAsync(){
            var founders= await _FounderService.GetAllFoundersAsync();
            var founderResponses = founders.Select(
                p=>new FounderResponse(
                    p.Id,
                    p.INN,
                    p.PersonName,
                    p.PersonSecondName,
                    p.PersonDadName,
                    p.DateCreate.ToString("g"),
                    p.DateUpdate.ToString("g"),
                    p.ClientId,
                    p.Client.INN,
                    p.Client.TypeClient
                )
            );

            return Ok(founderResponses);
        }
        [HttpPost]
        [Route("API/CreateFounder")]
        public async Task<ActionResult> CreateFounderAsync(Guid ClientId ,[FromBody] FounderRequest founderRequest){
            var (founder,error) = Founder.createFounder(
                Guid.NewGuid(),
                founderRequest.INN, 
                founderRequest.Name, 
                founderRequest.SecondName,
                founderRequest.DadName, 
                DateTime.Now,
                DateTime.Now,
                ClientId
            );
            if(!String.IsNullOrEmpty(error)){
                return  BadRequest(error);
            }
            await _FounderService.CreateFounderAsync(founder);
            return Ok(200);
        }
        [HttpPut]
        [Route("API/UpdateFounder/{FounderId:guid}")]
        public async Task<ActionResult> UpdateFounderAsync(Guid FounderId, [FromBody] FounderRequest founderRequest){
            var (founder,error) = Founder.createFounder(
                FounderId,
                founderRequest.INN,
                founderRequest.Name,
                founderRequest.SecondName,
                founderRequest.DadName
            );
            if(!String.IsNullOrEmpty(error)){
                return BadRequest(error);
            }
            await _FounderService.UpdateFounderAsync(FounderId,founder.INN,founder.PersonName,founder.PersonSecondName,founder.PersonDadName, DateTime.Now);
            return Ok(200);
        }
        [HttpDelete]
        [Route("API/DeleteFounder/{FounderId:guid}")]
        public async Task<ActionResult> DeleteFounderAsync(Guid FounderId){
            await _FounderService.DeleteFounderAsync(FounderId);
            return Ok(200);
        }

    }
}