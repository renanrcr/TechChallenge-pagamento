using API.Controllers.Base;
using Application.Commands.Webhooks;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Webhook")]
    public class WebhookMercadoPagoController : BaseController
    {
        private readonly IMediator _mediator;
        protected WebhookMercadoPagoController(INotificador notificador,
            IMediator mediator) 
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] long id, [FromQuery] string topic)
        {
            var entidade = await _mediator.Send(new AtualizaStatusPagamentoCommand { Id = id, Topic = topic });

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}
