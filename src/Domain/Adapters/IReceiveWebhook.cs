using Microsoft.AspNetCore.Mvc;

namespace Domain.Adapters
{
    public interface IReceiveWebhook
    {
        Task<JsonResult> ProcessRequest(string requestBody);
    }
}
