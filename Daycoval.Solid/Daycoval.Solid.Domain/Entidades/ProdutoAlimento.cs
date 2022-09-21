using Daycoval.Solid.Domain.Impostos;
using Daycoval.Solid.Domain.Services;
using Daycoval.Solid.Domain.Services.Impostos;

namespace Daycoval.Solid.Domain.Entidades
{
    public class ProdutoAlimento : ProdutoBase
    {
        public ProdutoAlimento(): base(TipoProduto.Alimentos)
        {
        }
        public override decimal RealizaCalculoImposto()
        {
            IImpostoTipo imposto = new AlimentoImposto();
            return imposto.CalcularImposto(base.Valor);
        }
        public override decimal CalularValorTotalProduto()
        {
            return (Valor + ValorImposto) * Quantidade;
        }
    }
}