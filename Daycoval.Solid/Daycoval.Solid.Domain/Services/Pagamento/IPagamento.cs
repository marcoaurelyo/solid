using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services.Pagamento
{
    public interface IPagamento
    {
        bool RealizarPagamento(DetalhePagamento detalhePagamento, decimal valorTotalpedido);
    }
}
