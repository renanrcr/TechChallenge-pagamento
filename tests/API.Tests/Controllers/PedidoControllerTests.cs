using API.Controllers;
using Application.Commands.ItensPedido;
using Application.Commands.Pedidos;
using Domain.Adapters;
using Infrastructure.Repositories;
using Infrastructure.Tests.Adapters;
using MediatR;
using Moq;

namespace API.Tests.Controllers
{
    public class PedidoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly PedidoController _pedidoController;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _pedidoController = new PedidoController(_notification.Object, _mediatorMock.Object);
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_ListarPedidos()
        {
            //Arrange

            //Act
            var result = _pedidoController.Get().Result;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoCriarPedido()
        {
            //Arrange
            var pedido = _pedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new();
            var command = new CadastraPedidoCommand();
            command.IdentificacaoClienteId = pedido.Id;

            //Act
            var result = _pedidoController.Post(command).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
