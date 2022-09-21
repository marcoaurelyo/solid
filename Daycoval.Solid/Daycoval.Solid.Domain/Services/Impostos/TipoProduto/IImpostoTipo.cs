using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    public interface IImpostoTipo
    {
        decimal CalcularImposto(decimal produto);
    }
}
