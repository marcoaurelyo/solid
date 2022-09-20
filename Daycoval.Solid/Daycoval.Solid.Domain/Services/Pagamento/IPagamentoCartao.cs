using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public interface IPagamentoCartao : IPagamento
    {
        string NomeImpresso { get; set; }
        decimal Valor { get; set; }
        int MesExpiracao { get; set; }
        int AnoExpiracao { get; set; }
        FormaPagamentoCartao FormaPagamentoCartao { get; set; }
    }
}
