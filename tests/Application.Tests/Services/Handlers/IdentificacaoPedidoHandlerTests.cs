using Application.AutoMapper;
using Application.Commands.IdentificacoesPedido;
using Application.Services.Handlers;
using AutoMapper;
using Domain.Adapters;
using Domain.Enums;
using Domain.Notificacoes;
using Infrastructure.Tests.Adapters;

namespace Application.Tests.Services.Handlers
{
    public class IdentificacaoPedidoHandlerTests
    {
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly IdentificacaoPedidoHandler _identificacaoPedidoHandler;

        public IdentificacaoPedidoHandlerTests()
        {
            _identificacaoPedidoRepository = IIdentificacaoPedidoRepositoryMock.GetMock();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _identificacaoPedidoHandler = new IdentificacaoPedidoHandler(_notificador, _identificacaoPedidoRepository, _mapper);
        }

        [Fact]
        public void IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CadastraIdentificacaoPedidoCommand()
            {
                Valor = "ahsdufhaushdfuhasd",
                TipodIdentificacaoPedido = (int)ETipoIdentificacaoPedido.CLIENTE
            };

            //Act
            var result = _identificacaoPedidoHandler.Handle(command, default).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
