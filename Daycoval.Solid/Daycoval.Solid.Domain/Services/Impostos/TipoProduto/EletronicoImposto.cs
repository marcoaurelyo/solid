using Daycoval.Solid.Domain.Services;

namespace Daycoval.Solid.Domain.Impostos
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
