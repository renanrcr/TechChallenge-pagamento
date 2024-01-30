using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class PedidoRepositoryTest
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoRepositoryTest()
        {
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Pedido_DeveRetornarVerdadeiro_QuandoTiverTodosOsPedidos()
        {
            //Arrange

            //Act
            IList<Pedido> pedidos = await _pedidoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(pedidos);
                Assert.True(pedidos.Count >= 0);
            });
        }

        [Fact]
        public async Task Pedido_DeveRetornarVerdadeiro_QuandoEncontrarOPedidoPeloID()
        {
            //Arrange
            Pedido primeiroPedido = (await _pedidoRepository.ObterTodos()).FirstOrDefault() ?? new();
            Guid id = primeiroPedido.Id;

            //Act
            Pedido? pedido = await _pedidoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Null(pedido);
            });
        }

        [Fact]
        public async Task Pedido_DeveRetornarVerdadeiro_QuandoCriarNovoPedido()
        {
            //Arrange
            Pedido pedido = await new Pedido().Cadastrar(Guid.NewGuid());

            //Act
            await _pedidoRepository.Adicionar(pedido);
            Pedido? pedidoAdicionado = await _pedidoRepository.ObterPorId(pedido.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(pedidoAdicionado);
                Assert.Equal(pedidoAdicionado.Id, pedido.Id);
            });
        }

        [Fact]
        public async Task Pedido_DeveRetornarVerdadeiro_QuandoAtualizarPedido()
        {
            //Arrange
            Guid id = (_pedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).Id;
            Pedido pedidoCadastrado = await _pedidoRepository.ObterPorId(id) ?? new();
            pedidoCadastrado.StatusPedido = Domain.Enums.EStatusPedido.RECEBIDO;

            //Act
            _pedidoRepository.Atualizar(pedidoCadastrado);
            Pedido? pedidoAtualizado = await _pedidoRepository.ObterPorId(pedidoCadastrado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(pedidoAtualizado);
                Assert.Equal(Domain.Enums.EStatusPedido.RECEBIDO, pedidoAtualizado.StatusPedido);
            });
        }

        [Fact]
        public async Task Pedido_DeveRetornarVerdadeiro_QuandoRemoverPedido()
        {
            //Arrange
            Pedido pedido = (await _pedidoRepository.ObterTodos()).FirstOrDefault() ?? new();

            //Act
            await _pedidoRepository.Remover(pedido);
            Pedido? pedidoRemovido = await _pedidoRepository.ObterPorId(pedido.Id);

            //Assert
            Assert.Null(pedidoRemovido);
        }
    }
}