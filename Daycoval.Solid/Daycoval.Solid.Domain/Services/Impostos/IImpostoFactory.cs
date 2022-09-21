using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services.Impostos
{
    public interface IImpostoFactory
    {
        IImposto GetObjectImposto();
    }
}
