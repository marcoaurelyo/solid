using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Impostos
{

    public interface IImpostometro {
        decimal executarCalculoDoImposto(decimal valor);
        void setImpostoStrategy(IImposto strategy);
    }
    public class Impostometro
    {
        // Mantém a referência para a strategy, perceba que ele não sabe qual a
        // interface concreta é escolhida. Ele pode trabalhar com todas as strategies
        // através da interface impostoStrategy
        IImposto impostoStrategy;

        public decimal executarCalculoDoImposto(decimal valor)
        {
            return impostoStrategy.CalcularImposto(valor);
        }

        public void setImpostoStrategy(IImposto strategy)
        {
            this.impostoStrategy = strategy;
        }
    }
}
