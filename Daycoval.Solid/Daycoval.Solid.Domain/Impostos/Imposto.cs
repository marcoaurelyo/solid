using Daycoval.Solid.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Impostos
{
    public interface  IImposto
    {
        decimal CalcularImposto(decimal valoProduto);
    }
}
