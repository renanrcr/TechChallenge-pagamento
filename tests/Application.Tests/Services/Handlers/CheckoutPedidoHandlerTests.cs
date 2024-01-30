using Application.AutoMapper;
using Application.Commands;
using Application.DTOs;
using Application.Services.Handlers;
using AutoMapper;
using Domain.Adapters;
using Domain.Enums;
using Domain.Notificacoes;
using MediatR;
using Moq;

namespace Application.Tests.Services.Handlers
{
    public class CheckoutPedidoHandlerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly CheckoutPedidoHandler _checkoutPedidoHandler;

        public CheckoutPedidoHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _checkoutPedidoHandler = new CheckoutPedidoHandler(_notificador, _mapper, _mediatorMock.Object);
        }

        [Fact]
        public void CheckoutPedido_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CheckoutPedidoCommand()
            {
                TipodIdentificacaoCliente = (int)ETipoIdentificacaoPedido.CLIENTE,
                IdentificacaoCliente = "ahsufdhaushfd23",
                ItensPedido = new Mock<List<ItemPedidoDTO>>().Object,
            };

            //Act
            var result = _checkoutPedidoHandler.Handle(command, default).Result;

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Pedido);
        }
    }
}
