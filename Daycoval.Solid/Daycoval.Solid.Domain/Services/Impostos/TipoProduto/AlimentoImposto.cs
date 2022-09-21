using Daycoval.Solid.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Impostos.TipoProduto
{
    public class AlimentoImposto : IImpostoTipo
    {
        private const decimal aliquota = 0.05M;
        public decimal CalcularImposto(decimal produto)
        {
           return produto * getTaxasAlimento();
        }

        public decimal getTaxasAlimento()
        {
            return aliquota;
        }
    }
}
