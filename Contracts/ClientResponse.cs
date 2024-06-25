

using job_tasks.Models;

namespace job_tasks.Contracts{
    public record ClientResponse(
        Guid Id,
        String INN,
        String Type,
        String DateCreate,
        String DateUpdate,
        List<FoundersForClientResponse> founderResponses
    );
       
    
}
