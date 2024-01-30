using Application.DTOs;
using Domain.Enums;

namespace Application.Tests.DTOs
{
    public class CheckoutPedidoDTOTests
    {
        [Fact]
        public void CheckoutPedidoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            Guid pedidoID = Guid.NewGuid();
            string numeroPedido = "102394jqsfjklasfdjkl";
            EStatusPedido eStatusPedido = EStatusPedido.PRONTO;

            // Act
            var dto = new CheckoutPedidoDTO
            {
                Pedido = new PedidoDTO
                {
                    IdentificacaoPedidoId = pedidoID,
                    NumeroPedido = numeroPedido,
                    EstatusPedido = eStatusPedido,
                },                
            };

            // Assert
            Assert.Equal(pedidoID, dto.Pedido.IdentificacaoPedidoId);
            Assert.Equal(numeroPedido, dto.Pedido.NumeroPedido);
            Assert.Equal(eStatusPedido, dto.Pedido.EstatusPedido);
        }
    }
}
