using API.Controllers;
using Application.AutoMapper;
using Application.Commands.IdentificacoesPedido;
using AutoMapper;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using MediatR;
using Moq;

namespace API.Tests.Controllers
{
    public class IdentificacaoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IMapper _mapper;
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;
        private readonly IdentificacaoController _identificacaoController;

        public IdentificacaoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _identificacaoPedidoRepository = IIdentificacaoPedidoRepositoryMock.GetMock();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _identificacaoController = new IdentificacaoController(_notification.Object, _mediatorMock.Object, _mapper, _identificacaoPedidoRepository);
        }

        [Fact]
        public void IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoEncontrarIdentificacoes()
        {
            //Arrange

            //Act
            var result = _identificacaoController.Get().Result;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IdentificacaoPedido_DeveRetornarVerdadeiro_QuandoCriarIdentificacao()
        {
            //Arrange
            var identificacao = _identificacaoPedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new();
            var command = new CadastraIdentificacaoPedidoCommand();
            command.Valor = identificacao.Valor;
            command.TipodIdentificacaoPedido = (int)identificacao.TipoIdentificacaoPedido;

            //Act
            var result = _identificacaoController.Post(command).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
