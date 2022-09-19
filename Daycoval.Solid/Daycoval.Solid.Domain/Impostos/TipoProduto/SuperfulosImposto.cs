﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Impostos.TipoProduto
{
    public class SuperfulosImposto : IImposto
    {
        private const decimal aliquota = 0.20M;
        public decimal CalcularImposto(decimal produto)
        {
            return produto * aliquota;
        }
    }
}
