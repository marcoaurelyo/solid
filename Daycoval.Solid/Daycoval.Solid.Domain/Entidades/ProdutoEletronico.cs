using Daycoval.Solid.Domain.Impostos;
using Daycoval.Solid.Domain.Services;

namespace Daycoval.Solid.Domain.Entidades
{
    public class ProdutoEletronico : ProdutoBase
    {
        public ProdutoEletronico() : base(TipoProduto.Eletronico)
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