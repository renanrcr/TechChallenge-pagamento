using Application.AutoMapper;
using Application.Commands.ItensPedido;
using Application.Services.Handlers;
using AutoMapper;
using Domain.Adapters;
using Domain.Notificacoes;
using Infrastructure.Tests.Adapters;

namespace Application.Tests.Services.Handlers
{
    public class ItemPedidoHandlerTests
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly ItemPedidoHandler _itemPedidoHandler;

        public ItemPedidoHandlerTests()
        {
            _itemPedidoRepository = IItemPedidoRepositoryMock.GetMock();
            _produtoRepository = IProdutoRepositoryMock.GetMock();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _itemPedidoHandler = new ItemPedidoHandler(_notificador, _itemPedidoRepository, _mapper, _produtoRepository);
        }

        [Fact]
        public void ItemPedido_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CadastraItemPedidoCommand()
            {
                PedidoId = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                Quantidade = 2,
            };

            //Act
            var result = _itemPedidoHandler.Handle(command, default).Result;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ItemPedido_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var dado = _itemPedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new();
            decimal quantidade = 1;

            var command = new AtualizaItemPedidoCommand()
            {
                Id = dado.Id,
                Quantidade = 1,
            };

            //Act
            var result = _itemPedidoHandler.Handle(command, default).Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(quantidade, result.Quantidade);
        }

        [Fact]
        public void ItemPedido_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var dado = _itemPedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new();

            var command = new DeletaItemPedidoCommand()
            {
                Id = dado.Id,
            };

            //Act
            var result = _itemPedidoHandler.Handle(command, default).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
