using API.Controllers;
using Application.Commands;
using Application.DTOs;
using Domain.Adapters;
using MediatR;
using Moq;

namespace API.Tests.Controllers
{
    public class CheckoutPedidoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;

        public CheckoutPedidoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
        }

        [Fact]
        public void CheckoutPedido_DeveRetornarVerdadeiro_CriarPedido()
        {
            //Arrange
            var controllerCheckoutPedido = new CheckoutPedidoController(_notification.Object, _mediatorMock.Object);
            var command = new CheckoutPedidoCommand();
            command.ItensPedido = new List<ItemPedidoDTO>() { new Mock<ItemPedidoDTO>().Object };
            //Act
            var result = controllerCheckoutPedido.Post(command).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
