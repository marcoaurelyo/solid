using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Services.Estoque;
using System.Runtime.InteropServices;

namespace Daycoval.Solid.Domain.Services
{
    public class EstoqueService : IEstoque
    {
        public void VerificarCarrinho(Carrinho carrinho)
        {

            if (carrinho.FoiPago)
            {
                foreach (var produto in carrinho.Produtos)
                {
                    SolicitarProduto(produto);
                }

                EntregarProdutos(carrinho);
            }
            else
            {
                throw new ExternalException("O pagamento não foi efetuado.");
            }

        }
        private void SolicitarProduto(ProdutoBase produto)
        {
            //Este método não precisa ser implementado.
        }
        private void EntregarProdutos(Carrinho carrinho)
        {
            carrinho.FoiEntregue = true;
        }

        public void BaixarEstoque(Carrinho carrinho)
        {
            if (carrinho.FoiEntregue)
            {
                //Este método não precisa ser implementado. // sucesso
            }
            else {
                throw new ExternalException("Os produtos não foram entregues.");
            }
            
        }
    }
}