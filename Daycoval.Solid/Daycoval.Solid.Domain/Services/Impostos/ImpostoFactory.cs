using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services.Impostos
{
    public class ImpostoFactory : IImpostoFactory
    {
        public IImposto GetObjectImposto()
        {
            return new ImpostoService();
        }
    }
}
