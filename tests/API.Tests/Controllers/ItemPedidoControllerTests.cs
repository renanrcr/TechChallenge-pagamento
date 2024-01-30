using API.Controllers;
using Application.AutoMapper;
using Application.Commands.ItensPedido;
using AutoMapper;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using MediatR;
using Moq;

namespace API.Tests.Controllers
{
    public class ItemPedidoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IMapper _mapper;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly ItemPedidoController _itemPedidoController;

        public ItemPedidoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _itemPedidoRepository = IItemPedidoRepositoryMock.GetMock();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _itemPedidoController = new ItemPedidoController(_notification.Object, _mediatorMock.Object, _mapper, _itemPedidoRepository);
        }

        [Fact]
        public void ItemPedido_DeveRetornarVerdadeiro_QuandoEncontrarItensPedido()
        {
            //Arrange

            //Act
            var result = _itemPedidoController.Get().Result;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ItemPedido_DeveRetornarVerdadeiro_QuandoCriarItemPedido()
        {
            //Arrange
            var itemPedido = _itemPedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new();
            var command = new CadastraItemPedidoCommand();
            command.PedidoId = itemPedido.PedidoId;
            command.ProdutoId = itemPedido.ProdutoId;
            command.Quantidade = itemPedido.Quantidade;

            //Act
            var result = _itemPedidoController.Post(command).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
