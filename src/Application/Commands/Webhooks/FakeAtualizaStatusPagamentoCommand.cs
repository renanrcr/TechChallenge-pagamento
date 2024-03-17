using MediatR;

namespace Application.Commands.Webhooks
{
    public class FakeAtualizaStatusPagamentoCommand : IRequest<bool>
    {
        public Guid Id { get; set; } = new();
        public string Topic { get; set; } = string.Empty;
        public string Status { get; set; } = "closed";
    }
}
