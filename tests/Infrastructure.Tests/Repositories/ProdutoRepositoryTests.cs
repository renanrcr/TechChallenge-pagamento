using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class ProdutoRepositoryTests
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoRepositoryTests()
        {
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange

            //Act
            var dado = await _produtoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.True(dado.Count > 0);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            Guid id = ((await _produtoRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            var dado = await _produtoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.Equal(dado.Id, id);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            var novoDado = new Produto();

            //Act
            await _produtoRepository.Adicionar(novoDado);
            var dadoCriado = await _produtoRepository.ObterPorId(novoDado.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoCriado);
                Assert.Equal(dadoCriado.Id, novoDado.Id);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            Guid id = (_produtoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).Id;
            var dado = await _produtoRepository.ObterPorId(id) ?? new();

            //Act
            await _produtoRepository.Atualizar(dado);
            var dadoAtualizado = await _produtoRepository.ObterPorId(dado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoAtualizado);
                Assert.Equal(dado.Id, dadoAtualizado.Id);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var dado = (await _produtoRepository.ObterTodos()).FirstOrDefault() ?? new();

            //Act
            _produtoRepository.Remover(dado);
            var dadoRemovido = await _produtoRepository.ObterPorId(dado.Id);

            //Assert
            Assert.Null(dadoRemovido.ItemPedido);
        }
    }
}
