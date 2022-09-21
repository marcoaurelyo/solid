using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Impostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services.Impostos
{
    public interface IImposto
    {
        decimal RealizaCalculo(Produto produto);
    }
}
