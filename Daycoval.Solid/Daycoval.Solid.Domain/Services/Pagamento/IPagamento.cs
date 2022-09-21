using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services.Pagamento
{
    public interface IPagamento
    {
        void RealizarPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento);
    }
}
