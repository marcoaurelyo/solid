using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public interface IEstoqueService
    {
        void SolicitarProduto(Produto produto);
        void BaixarEstoque(Produto produto);
    }
    public class EstoqueService : IEstoqueService
    {
        public void SolicitarProduto(Produto produto)
        {
            //Este método não precisa ser implementado.
        }

        public void BaixarEstoque(Produto produto)
        {
            //Este método não precisa ser implementado.
        }
    }
}