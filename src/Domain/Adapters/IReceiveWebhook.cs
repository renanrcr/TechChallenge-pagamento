using Microsoft.AspNetCore.Mvc;

namespace TechChallenge.src.Core.Domain.Adapters
{
    public interface IReceiveWebhook
    {
        Task<JsonResult> ProcessRequest(string requestBody);
    }
}
