using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Impostos;
using Daycoval.Solid.Domain.Impostos.TipoProduto;
using Daycoval.Solid.Domain.Services.Estoque;

namespace Daycoval.Solid.Domain.Services
{
    public class PedidoServices
    {
        IEstoque _estoqueService;
        IImposto _imposto;

        IEmailMessage _emailMessageService;
        INotificar _smsService;

        IPagamentoCartao _pagamentoCartaoService;
        IPagamento _pagamentoDinheiroService;

        public PedidoServices(IEstoque estoqueService, IEmailMessage emailMessageService, INotificar smsService, IPagamentoCartao pagamentoCartaoService,IPagamento pagamentoDinheiroService)
        {
            this._estoqueService = estoqueService;
            this._emailMessageService = emailMessageService;
            this._smsService = smsService;
            this._pagamentoCartaoService = pagamentoCartaoService;
            this._pagamentoDinheiroService = pagamentoDinheiroService;
        }

        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            //Utilzado Strategy Pattern 
            CalcularImposto(carrinho);

            if (RealizarPagamento(detalhePagamento, carrinho.ValorTotalPedido))
                InformarPagamento(carrinho);

            if (carrinho.FoiPago)
            {
                foreach (var produto in carrinho.Produtos)
                {
                    _estoqueService.SolicitarProduto(produto);
                }

                EntregarProdutos(carrinho);
            }
            else
            {
                throw new ExternalException("O pagamento não foi efetuado.");
            }

            if (carrinho.FoiEntregue)
            {
                foreach (var produto in carrinho.Produtos)
                {
                    _estoqueService.BaixarEstoque(produto);
                }
            }
            else
            {
                throw new ExternalException("Os produtos não foram entregues.");
            }

            RealizarNotificacao(carrinho, notificarClienteEmail, notificarClienteSms);
        }

        private void CalcularImposto(Carrinho carrinho)
        {
            foreach (var produto in carrinho.Produtos)
            {
                if (produto.TipoProduto == TipoProduto.Alimentos)
                {
                    _imposto = new AlimentoImposto();
                    produto.ValorImposto = _imposto.CalcularImposto(produto.Valor);
                    carrinho.ValorTotalPedido += CalcularValorTotalPedido(produto);
                }
                else
                {
                    if (produto.TipoProduto == TipoProduto.Eletronico)
                    {
                        _imposto = new EletronicoImposto();
                        produto.ValorImposto = _imposto.CalcularImposto(produto.Valor);
                        carrinho.ValorTotalPedido += CalcularValorTotalPedido(produto);
                    }
                    else
                    {
                        if (produto.TipoProduto == TipoProduto.Superfulos)
                        {
                            _imposto = new SuperfulosImposto();
                            produto.ValorImposto = _imposto.CalcularImposto(produto.Valor);
                            carrinho.ValorTotalPedido += CalcularValorTotalPedido(produto);
                        }
                        else
                        {
                            throw new ArgumentException("O tipo de produto informado não está disponível.");
                        }
                    }
                }
            }
        }
        public bool RealizarPagamento(DetalhePagamento detalhePagamento, decimal valorPedido)
        {
            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.CartaoCredito) ||
      detalhePagamento.FormaPagamento.Equals(FormaPagamento.CartaoDebito))
            {
                this._pagamentoCartaoService.NomeImpresso = detalhePagamento.NomeImpressoCartao;
                this._pagamentoCartaoService.AnoExpiracao = detalhePagamento.AnoExpiracao;
                this._pagamentoCartaoService.MesExpiracao = detalhePagamento.MesExpiracao;
                this._pagamentoCartaoService.Valor = valorPedido;

                this._pagamentoCartaoService.EfetuarPagamento();

                return true;
            }

            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.Dinheiro))
            {
                this._pagamentoDinheiroService.EfetuarPagamento();
                return true;
            }

            return false;
        }
        public void RealizarNotificacao(Carrinho carrinho, bool notificarClienteEmail, bool notificarClienteSms)
        {
            if (notificarClienteEmail)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Email))
                {
                    this._emailMessageService.Subject = "Dados da sua compra";
                    this._emailMessageService.enviar(carrinho.Cliente.Email, $"Obrigado por efetuar sua compra conosco.");
                }
            }

            if (notificarClienteSms)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Celular))
                {
                    this._smsService.enviar(carrinho.Cliente.Celular, "Obrigado por sua compra");
                }
            }
        }

        public decimal CalcularValorTotalPedido(Produto produto)
        {
            return (produto.Valor + produto.ValorImposto) * produto.Quantidade;
        }
        private void EntregarProdutos(Carrinho carrinho)
        {
            carrinho.FoiEntregue = true;
        }
        private void InformarPagamento(Carrinho carrinho)
        {
            carrinho.FoiPago = true;
        }
    }
}