using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services.Estoque
{
    public interface IEstoque
    {
        void SolicitarProduto(Produto produto);
        void BaixarEstoque(Produto produto);
    }
}
