using API.Controllers.Base;
using Application.Commands.Webhooks;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("FakeWebhookUpdate")]
    public class FakeWebhookMercadoPagoController : BaseController
    {
        private readonly IMediator _mediator;

        protected FakeWebhookMercadoPagoController(INotificador notificador,
            IMediator mediator)
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FakeAtualizaStatusPagamentoCommand command)
        {
            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}
