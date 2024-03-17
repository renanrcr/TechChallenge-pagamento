using API.Controllers.Base;
using Application.Commands.QrCodes;
using Domain.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Pagamento")]
    public class PagamentoController : BaseController
    {
        private readonly IMediator _mediator;

        protected PagamentoController(INotificador notificador,
            IMediator mediator) 
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpGet("cria-qr-code")]
        public async Task<IActionResult> Get(Guid pedidoId)
        {
            var entidade = await _mediator.Send(new QrCodeCommand { PedidoId = pedidoId });

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}
