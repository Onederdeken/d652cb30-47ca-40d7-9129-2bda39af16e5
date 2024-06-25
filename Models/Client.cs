using Microsoft.EntityFrameworkCore;

namespace job_tasks.Models{
    public class Client{
        public const String UL = "ЮЛ";
        public const String IP = "ИП";
       
        protected Client(Guid id, String inn, String type, DateTime create, DateTime update){
            this.Id=id;
            this.DateCreate=create;
            this.DateUpdate=update;
            this.TypeClient=type;
            this.INN = inn;
        }
        protected Client(Guid id, String inn, String type){
            this.Id=id;
            this.TypeClient=type;
            this.INN = inn;
        }
        public Guid Id{get;}
        public String INN{get;}=String.Empty;
        public String TypeClient{get;}
        public DateTime DateCreate{get;}
        public DateTime DateUpdate{get;}
        public List<Founder>? Founders;

        public static (Client client, String Error) Create(Guid id, String inn, String type, DateTime create, DateTime update){
            String Error = verification(inn,type);
            return (new Client(id, inn, type, create, update),Error);
        }
        public static (Client client, String Error) Create(Guid id, String inn, String type){
            String Error = verification(inn,type);
            return (new Client(id, inn, type),Error);
        }
        protected static String verification(String inn, String Type){
            long number;
            if(inn.Length != 12){
                return "инн должен состоять из 12 цифр";
            }
            else if(long.TryParse(inn,out number) == false){
                return "инн должен состоять из цифр";
            }
            else if(Type != UL && Type != IP){
                return "Клиентами могут быть только юридичесĸие лица (ЮЛ) или ииндивидуальные предприниматели (ИП)";
            }
            return String.Empty;
        }

    }
}