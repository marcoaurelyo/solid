using Daycoval.Solid.Domain.Entidades;
using System;

namespace Daycoval.Solid.Domain.Services
{
    public class GatewayPagamentoCartaoService : IPagamentoCartao, IDisposable
    {
        private string login;
        private string senha;
        public string NomeImpresso { get; set; }
        public decimal Valor { get; set; }
        public int MesExpiracao { get; set; }
        public int AnoExpiracao { get; set; }
        public FormaPagamentoCartao FormaPagamentoCartao { get; set; }
        public GatewayPagamentoCartaoService()
        {
            this.login = "login";
            this.senha = "senha";
        }
        public void EfetuarPagamento()
        {
            //autenticar
            Console.WriteLine(login + senha);
            Console.WriteLine("pagamento efetuado");
            //Não é necessário implementar este método.
        }
        public void Dispose()
        {
            this.login = string.Empty;
            this.senha = string.Empty;
            NomeImpresso = string.Empty;
            Valor = 0M;
            MesExpiracao = 0;
            AnoExpiracao = 0;
        }
    }
}