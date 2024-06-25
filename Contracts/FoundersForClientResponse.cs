

namespace job_tasks.Contracts{
    public record FoundersForClientResponse(
        Guid Id,
        String INN,
        String Name,
        String SecondName,
        String DadName,
        String DateCreate,
        String DateUpdate
    );
       
    
}