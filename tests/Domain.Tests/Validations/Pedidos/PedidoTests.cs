using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Tests.Adapters;

namespace Domain.Tests.Validations.Pedidos
{
    public class PedidoTests
    {
        private readonly IProdutoRepository _produtoRepository;

        public PedidoTests()
        {
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoExistirItem()
        { 
            //Arrange
            Pedido? pedido = await new Pedido().Cadastrar(Guid.NewGuid());
            Guid produtoId = (_produtoRepository.ObterTodos().Result.FirstOrDefault() ?? new Produto()).Id;

            //Act
            ItemPedido? item = new ItemPedido().Cadastrar(_produtoRepository, pedido.Id, produtoId, 1).Result;
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(item);
                Assert.False(item.IsValid);
            });
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarFalso_QuandoNaoExistirItem()
        { 
            //Arrange
            Pedido? pedido = await new Pedido().Cadastrar(Guid.NewGuid());
            Guid produtoId = Guid.NewGuid();

            //Act
            ItemPedido? item = new ItemPedido().Cadastrar(_produtoRepository, pedido.Id, produtoId, 1).Result;
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(item);
                Assert.False(item?.IsValid);
            });
        }
    }
}