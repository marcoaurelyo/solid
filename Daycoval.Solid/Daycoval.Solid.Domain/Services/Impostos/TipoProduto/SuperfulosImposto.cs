using Daycoval.Solid.Domain.Services;

namespace Daycoval.Solid.Domain.Impostos
{
    public class SuperfulosImposto : IImpostoTipo
    {
        private const decimal aliquota = 0.20M;
        public decimal CalcularImposto(decimal produto)
        {
            return produto * getTaxasSuperfulos();
        }

        public decimal getTaxasSuperfulos()
        {
            return aliquota;
        }
    }
}
