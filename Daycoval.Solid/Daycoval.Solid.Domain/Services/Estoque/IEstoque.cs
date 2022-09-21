using Daycoval.Solid.Domain.Entidades;
using System.Collections.Generic;

namespace Daycoval.Solid.Domain.Services.Estoque
{
    public interface IEstoque
    {
        void VerificarCarrinho(Carrinho carrinho);
        /*  void SolicitarProduto(Carrinho carrinho);  */
        void BaixarEstoque(Carrinho carrinho);
        /*void EntregarProdutos(Carrinho carrinho);*/
    }
}
