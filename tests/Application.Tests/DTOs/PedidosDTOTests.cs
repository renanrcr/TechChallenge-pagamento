using Application.DTOs;
using Domain.Enums;

namespace Application.Tests.DTOs
{
    public class PedidosDTOTests
    {
        [Fact]
        public void PedidosDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            string numeroPedido = "102394jqsfjklasfdjkl";
            string nome = "Lanche";
            decimal quantidade = 10;
            decimal valor = 2;
            EStatusPedido eStatusPedido = EStatusPedido.PRONTO;

            var itensDto = new ItensDTO
            {
                Nome = nome,
                Valor = valor,
                Quantidade = quantidade,
            };

            // Act
            var pedidosDTO = new PedidosDTO
            {
                NumeroPedido = numeroPedido,
                StatusPedido = eStatusPedido.ToString(),
                QuantidadeItens = quantidade,
                ItensPedido = new List<ItensDTO>() { itensDto },
            };

            // Assert
            Assert.Equal(numeroPedido, pedidosDTO.NumeroPedido);
            Assert.Equal(eStatusPedido.ToString(), pedidosDTO.StatusPedido);
        }
    }
}
