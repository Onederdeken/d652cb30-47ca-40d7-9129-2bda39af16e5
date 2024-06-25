using job_tasks.bd.Entities;
using Org.BouncyCastle.Utilities;

namespace job_tasks.Models{
    public class Founder{
        protected Founder(Guid id, String inn, String name, String SecondName, String DadName, DateTime create, DateTime update, Guid clientId ,Client client = null)
        {
            this.Id = id;
            this.INN = inn;
            this.Client = client;
            this.DateCreate = create;
            this.DateUpdate = update;
            this.PersonName = name;
            this.PersonSecondName=SecondName;
            this.PersonDadName=DadName;
            this.ClientId = clientId;
        }
        protected Founder(Guid id, String inn, String name,String SecondName, String DadName){
            this.Id = id;
            this.INN = inn;
            this.PersonName = name;
            this.PersonSecondName=SecondName;
            this.PersonDadName=DadName;
            
        }
        public Guid Id{get;}

        public String INN{get;}=String.Empty;
        public String PersonName{get;}=String.Empty;
        public String PersonSecondName{get;}=String.Empty;
        public String PersonDadName{get;}=String.Empty;
        public Guid ClientId{get;}
        public Client Client{get;}=null!;
        public DateTime DateCreate{get;}
        public DateTime DateUpdate{get;}

        public static (Founder founder, String Errors) createFounder(Guid id, String inn, String name,String SecondName, String DadName , DateTime create, DateTime update, Guid clientId ,Client client = null){
            String Error = verification(inn);
            
            if(client != null){
                return (new Founder(id,inn,name,SecondName,DadName,create,update, clientId ,client),Error);
            }
            else{
                return (new Founder(id,inn,name,SecondName,DadName,create,update,clientId),Error);
            }
            
        }
        public static (Founder founder, String Errors) createFounder(Guid id, String inn, String name,String SecondName, String DadName){
            String Error = verification(inn);
            return (new Founder(id,inn,name,SecondName,DadName),Error);
        }

        protected static String verification(String inn){
            long number;
            if(inn.Length != 12){
                return "инн должен состоять из 12 цифр";
            }
            else if(long.TryParse(inn,out number) == false){
                return "инн должен состоять из цифр";
            }
            return String.Empty;
        }
    }
}