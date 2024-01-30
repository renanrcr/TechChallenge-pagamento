using Domain.Adapters;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class IdentificacaoPedidoRepositoryTests
    {
        private IIdentificacaoPedidoRepository _identificacaoPedidoRepository;

        public IdentificacaoPedidoRepositoryTests()
        {
            _identificacaoPedidoRepository = IIdentificacaoPedidoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange

            //Act
            IList<IdentificacaoPedido> identificacaoPedidos = await _identificacaoPedidoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(identificacaoPedidos);
                Assert.True(identificacaoPedidos.Count > 0);
            });
        }

        [Fact]
        public async Task IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            Guid id = ((await _identificacaoPedidoRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            IdentificacaoPedido? identificacaoPedido = await _identificacaoPedidoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(identificacaoPedido);
                Assert.Equal(identificacaoPedido.Id, id);
            });
        }

        [Fact]
        public async Task IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            IdentificacaoPedido identificacaoPedido = new IdentificacaoPedido().NewInstance(Guid.NewGuid().ToString(), (int)ETipoIdentificacaoPedido.NAO_IDENTIFICADO);

            //Act
            _identificacaoPedidoRepository.Adicionar(identificacaoPedido);
            IdentificacaoPedido? identificacaoPedidoAdicionado = await _identificacaoPedidoRepository.ObterPorId(identificacaoPedido.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(identificacaoPedidoAdicionado);
                Assert.Equal(identificacaoPedidoAdicionado.Id, identificacaoPedido.Id);
            });
        }

        [Fact]
        public async Task IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            Guid id = (_identificacaoPedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).Id;
            IdentificacaoPedido identificacaoPedidoCadastrado = await _identificacaoPedidoRepository.ObterPorId(id) ?? new();
            identificacaoPedidoCadastrado.AtualizarIdentificacaoPedido(ETipoIdentificacaoPedido.CLIENTE);

            //Act
            await _identificacaoPedidoRepository.Atualizar(identificacaoPedidoCadastrado);
            IdentificacaoPedido? identificacaoPedidoAtualizado = await _identificacaoPedidoRepository.ObterPorId(identificacaoPedidoCadastrado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(identificacaoPedidoAtualizado);
                Assert.Equal(ETipoIdentificacaoPedido.CLIENTE, identificacaoPedidoAtualizado.TipoIdentificacaoPedido);
            });
        }

        [Fact]
        public async Task IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            IdentificacaoPedido identificacaoPedido = (await _identificacaoPedidoRepository.ObterTodos()).FirstOrDefault() ?? new();

            //Act
            await _identificacaoPedidoRepository.Remover(identificacaoPedido);
            IdentificacaoPedido? identificacaoPedidoRemovido = await _identificacaoPedidoRepository.ObterPorId(identificacaoPedido.Id);

            //Assert
            Assert.Null(identificacaoPedidoRemovido);
        }
    }
}
