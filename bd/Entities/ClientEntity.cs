using Microsoft.EntityFrameworkCore;

namespace job_tasks.bd.Entities{
    public class ClientEntity{
        public Guid Id{get;set;}
        public String INN{get;set;}=String.Empty;
        public String TypeClient{get;set;}=String.Empty;
        public DateTime DateCreate{get;set;}
        public DateTime DateUpdate{get;set;}
        public List<FounderEntity> Founders = new List<FounderEntity>();

    
    }
}