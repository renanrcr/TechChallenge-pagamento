using Application.DTOs;

namespace Application.Tests.DTOs
{
    public class ItemPedidoDTOTests
    {
        [Fact]
        public void ItemPedidoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            Guid pedidoID = Guid.NewGuid();
            Guid produtoID = Guid.NewGuid();
            decimal quantidade = 10;

            // Act
            var dto = new ItemPedidoDTO
            {
                PedidoId = pedidoID,
                ProdutoId = produtoID,
                Quantidade = quantidade,
            };

            // Assert
            Assert.Equal(pedidoID, dto.PedidoId);
            Assert.Equal(produtoID, dto.ProdutoId);
            Assert.Equal(quantidade, dto.Quantidade);
        }
    }
}
