using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Impostos.TipoProduto;
using Daycoval.Solid.Domain.Services.Impostos;
using System;

namespace Daycoval.Solid.Domain
{
    public class ImpostoService : IImposto
    {
        public decimal RealizaCalculo(Produto produto)
        {
            if (produto.TipoProduto == TipoProduto.Alimentos)
            {
               return new AlimentoImposto().CalcularImposto(produto.Valor);
            }
            else
            {
                if (produto.TipoProduto == TipoProduto.Eletronico)
                {
                    return new EletronicoImposto().CalcularImposto(produto.Valor);
                }
                else
                {
                    if (produto.TipoProduto == TipoProduto.Superfulos)
                    {
                        return new SuperfulosImposto().CalcularImposto(produto.Valor);
                    }
                    else
                    {
                        throw new ArgumentException("O tipo de produto informado não está disponível.");
                    }
                }
            }
        }
    }
}
