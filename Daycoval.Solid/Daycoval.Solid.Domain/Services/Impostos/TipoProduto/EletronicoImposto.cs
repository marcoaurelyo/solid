using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Impostos.TipoProduto
{
    public class EletronicoImposto : IImpostoTipo
    {
        private const decimal aliquota = 0.15M;
        public decimal CalcularImposto(decimal produto)
        {
            return produto * getTaxasEletronico();
        }

        public decimal getTaxasEletronico()
        {
            return aliquota;
        }
    }
}
