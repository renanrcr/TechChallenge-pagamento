using TechChallenge.src.Core.Application.Validations.Pedidos;
using TechChallenge.src.Core.Domain.Commands.Pedidos;
using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class Pedido : EntidadeBase<Guid>
    {
        public Guid IdentificacaoPedidoId { get; private set; }
        public string? NumeroPedido { get; private set; }
        public EStatusPedido StatusPedido { get; set; }
        public EStatusPagamentoPedido StatusPagamentoPedido { get; set; }
        public IdentificacaoPedido? IdentificacaoPedido { get; private set; }
        public ItemPedido? ItemPedido { get; internal set; }

        public async Task<Pedido> Cadastrar(CadastraPedidoCommand command)
        {
            Id = Guid.NewGuid();
            IdentificacaoPedidoId = command.IdentificacaoClienteId;
            StatusPedido = EStatusPedido.EM_PREPARACAO;
            NumeroPedido = RandomString(10);
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraPedidoValidation());

            return this;
        }

        public async Task<Pedido> Atualizar(AtualizaPedidoCommand command)
        {
            Id = Guid.NewGuid();
            NumeroPedido = command.NumeroPedido;
            IdentificacaoPedidoId = command.IdentificacaoPedidoId;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaPedidoValidation());

            return this;
        }

        public async Task<Pedido> Deletar(DeletaPedidoCommand command)
        {
            Id = command.Id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaPedidoValidation());

            return this;
        }

        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}