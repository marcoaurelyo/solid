using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Services.Pagamento;

namespace Daycoval.Solid.Domain.Services
{
    public class GatewayPagamentoService : IPagamento
    {
        public void RealizarPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.CartaoCredito) ||
      detalhePagamento.FormaPagamento.Equals(FormaPagamento.CartaoDebito))
            {
                var _pagamentoCartaoService = new GatewayPagamentoCartaoService();
                _pagamentoCartaoService.NomeImpresso = detalhePagamento.NomeImpressoCartao;
                _pagamentoCartaoService.AnoExpiracao = detalhePagamento.AnoExpiracao;
                _pagamentoCartaoService.MesExpiracao = detalhePagamento.MesExpiracao;
                _pagamentoCartaoService.Valor = carrinho.ValorTotalPedido;

                _pagamentoCartaoService.EfetuarPagamento();
                InformarPagamento(carrinho);
            }

            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.Dinheiro))
            {
                var _pagamentoDinheiroService = new GatewayPagamentoDinheiroService();
                _pagamentoDinheiroService.EfetuarPagamento();
                InformarPagamento(carrinho);
            }
        }

        private void InformarPagamento(Carrinho carrinho)
        {
            carrinho.FoiPago = true;
        }
    }
}

