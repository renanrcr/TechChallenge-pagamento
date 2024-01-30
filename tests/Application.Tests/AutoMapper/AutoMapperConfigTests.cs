using Application.AutoMapper;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Application.Tests.AutoMapper
{
    public class AutoMapperConfigTests
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public AutoMapperConfigTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task MapearPedidoParaPedidoDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            Pedido pedido = await new Pedido().Cadastrar(Guid.NewGuid());

            // Act
            PedidoDTO pedidoDto = _mapper.Map<PedidoDTO>(pedido);

            // Assert
            Assert.Equal(pedido.NumeroPedido, pedidoDto.NumeroPedido);
        }

        [Fact]
        public async Task MapearItemPedidoParaItemPedidoDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            ItemPedido itemPedido = await new ItemPedido().Cadastrar(_produtoRepository, Guid.NewGuid(), Guid.NewGuid(), 0);

            // Act
            ItemPedidoDTO itemPedidoDto = _mapper.Map<ItemPedidoDTO>(itemPedido);

            // Assert
            Assert.Equal(itemPedido.PedidoId, itemPedidoDto.PedidoId);
        }
    }
}
