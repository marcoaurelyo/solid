using Daycoval.Solid.Domain.Impostos;
using Daycoval.Solid.Domain.Services;

namespace Daycoval.Solid.Domain.Entidades
{
    public class ProdutoSuperfulos : ProdutoBase
    {
        public ProdutoSuperfulos() : base(TipoProduto.Superfulos)
        {
        }
        public override decimal RealizaCalculoImposto()
        {
            IImpostoTipo imposto = new EletronicoImposto();
            return imposto.CalcularImposto(base.Valor);
        }
        public override decimal CalularValorTotalProduto()
        {
            return (Valor + ValorImposto) * Quantidade;
        }
    }
}