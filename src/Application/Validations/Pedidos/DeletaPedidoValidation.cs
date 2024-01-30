using TechChallenge.src.Core.Application.Validations.Pedidos.Base;

namespace TechChallenge.src.Core.Application.Validations.Pedidos
{
    public class DeletaPedidoValidation : PedidoBaseValidation
    {
        public DeletaPedidoValidation()
        {
            ValidarDataExclusao();
        }
    }
}