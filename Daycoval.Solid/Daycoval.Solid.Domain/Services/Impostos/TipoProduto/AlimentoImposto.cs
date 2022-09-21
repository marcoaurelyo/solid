using Daycoval.Solid.Domain.Services;

namespace Daycoval.Solid.Domain.Impostos
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
