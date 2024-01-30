using Application.DTOs;

namespace Application.Tests.DTOs
{
    public class IdentificacaoPedidoDTOTests
    {
        [Fact]
        public void IdentificacaoPedidoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string valor = "102394jqsfjklasfdjkl";

            // Act
            var dto = new IdentificacaoPedidoDTO
            {
                Id = id,
                Valor = valor,
            };

            // Assert
            Assert.Equal(id, dto.Id);
            Assert.Equal(valor, dto.Valor);
        }
    }
}
