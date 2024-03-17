using MediatR;

namespace Application.Commands.Webhooks
{
    public class AtualizaStatusPagamentoCommand : IRequest<bool>
    {
        public long Id { get; set; } = new();
        public string Topic { get; set; } = string.Empty;
    }
}
