﻿using Microsoft.AspNetCore.Mvc;
using TechChallenge.src.Core.Domain.Adapters;

namespace API.WebHooks
{
    public class ConsoleWebhookReceiver : IReceiveWebhook
    {
        public async Task<JsonResult> ProcessRequest(string requestBody)
        {
            return await Task.FromResult(new JsonResult(new { mensagem = $"Mensagem recebida: {requestBody}" }));
        }
    }
}