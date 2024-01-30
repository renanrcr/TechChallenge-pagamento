using FluentValidation;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.Pedidos.Base
{
    public class PedidoBaseValidation : ValidationBase<Pedido>
    {
        public PedidoBaseValidation()
        {
            ValidarId();
            ValidarIdentificacaoPedido();
            ValidarDataCadastro();
        }

        public void ValidarIdentificacaoPedido()
        {
            RuleFor(x => x.IdentificacaoPedidoId).NotNull().WithMessage("Informe uma identificação.");
        }
    }
}