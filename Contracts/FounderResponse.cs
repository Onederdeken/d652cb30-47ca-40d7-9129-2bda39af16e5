

namespace job_tasks.Contracts{
    public record FounderResponse(
        Guid Id,
        String INN,
        String Name,
        String SecondName,
        String DadName,
        String DateCreate,
        String DateUpdate,
        Guid ClientId,
        String CLientInn,
        String ClientType
    );
       
    
}
