namespace job_tasks.bd.Entities{
    public class FounderEntity{
        public Guid Id{get;set;}
        public String INN{get;set;}=String.Empty;
        public String PersonName{get;set;}=String.Empty;
        public String PersonSecondName{get;set;}=String.Empty;
        public String PersonDadName{get;set;}=String.Empty;
        public Guid ClientId{get;set;}
        public ClientEntity? Client{get;set;} = new ClientEntity();
        public DateTime DateCreate{get;set;}
        public DateTime DateUpdate{get;set;}


    }
}