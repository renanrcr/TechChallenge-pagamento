using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class ItemPedidoRepositoryTests
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ItemPedidoRepositoryTests()
        {
            _itemPedidoRepository = IItemPedidoRepositoryMock.GetMock();
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange

            //Act
            var dado = await _itemPedidoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.True(dado.Count >= 0);
            });
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            Guid id = ((await _itemPedidoRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            var dado = await _itemPedidoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.Equal(dado.Id, id);
            });
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            Pedido? pedido = await new Pedido().Cadastrar(Guid.NewGuid());
            Guid produtoId = Guid.NewGuid();

            var novoDado = new ItemPedido().Cadastrar(_produtoRepository, pedido.Id, produtoId, 1).Result;

            //Act
            await _itemPedidoRepository.Adicionar(novoDado);
            var dadoCriado = await _itemPedidoRepository.ObterPorId(novoDado.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoCriado);
                Assert.Equal(dadoCriado.Id, novoDado.Id);
            });
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            Guid id = (_itemPedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).Id;
            var dado = await _itemPedidoRepository.ObterPorId(id) ?? new();
            await dado.Atualizar(_produtoRepository, id, 10);

            //Act
            await _itemPedidoRepository.Atualizar(dado);
            var dadoAtualizado = await _itemPedidoRepository.ObterPorId(dado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoAtualizado);
                Assert.Equal(dado.Id, dadoAtualizado.Id);
            });
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var dado = (await _itemPedidoRepository.ObterTodos()).FirstOrDefault() ?? new();

            //Act
            await _itemPedidoRepository.Remover(dado);
            var dadoRemovido = await _itemPedidoRepository.ObterPorId(dado.Id);

            //Assert
            Assert.Null(dadoRemovido);
        }
    }
}
