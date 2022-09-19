using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Impostos;
using Daycoval.Solid.Domain.Impostos.TipoProduto;

namespace Daycoval.Solid.Domain.Services
{
    public class Pedido
    {
        IEstoqueService _estoqueService;
        IImpostometro _impostometro;
        //Todo: Colocar a Classe Estoque como injeção de dependência
        public Pedido(IEstoqueService estoque, IImpostometro impostometro)
        {
            this._estoqueService = estoque;
            this._impostometro = impostometro;
        }

      
        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            #region Calcular Imposto
            foreach (var produto in carrinho.Produtos)
            {
                if (produto.TipoProduto == TipoProduto.Alimentos)
                {
                    _impostometro.setImpostoStrategy(new AlimentoImposto());
                    produto.ValorImposto = _impostometro.executarCalculoDoImposto(produto.Valor);
                    carrinho.ValorTotalPedido += CalcularValorTotalPedido(produto);
                }
                else
                {
                    if (produto.TipoProduto == TipoProduto.Eletronico)
                    {
                        _impostometro.setImpostoStrategy(new EletronicoImposto());
                        produto.ValorImposto = _impostometro.executarCalculoDoImposto(produto.Valor);
                        carrinho.ValorTotalPedido += CalcularValorTotalPedido(produto);
                    }
                    else
                    {
                        if (produto.TipoProduto == TipoProduto.Superfulos)
                        {
                            _impostometro.setImpostoStrategy(new SuperfulosImposto());
                            produto.ValorImposto = _impostometro.executarCalculoDoImposto(produto.Valor);
                            carrinho.ValorTotalPedido += CalcularValorTotalPedido(produto);
                        }
                        else
                        {
                            throw new ArgumentException("O tipo de produto informado não está disponível.");
                        }
                    }
                }
            }
            #endregion

            #region Pagamento
            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.CartaoCredito) ||
                detalhePagamento.FormaPagamento.Equals(FormaPagamento.CartaoDebito))
            {

                using (var gatewayPatamento = new GatewayPagamentoService())
                {
                    gatewayPatamento.Login = "login";
                    gatewayPatamento.Senha = "senha";
                    gatewayPatamento.FormaPagamentoCartao = (FormaPagamentoCartao)detalhePagamento.FormaPagamento;
                    gatewayPatamento.NomeImpresso = detalhePagamento.NomeImpressoCartao;
                    gatewayPatamento.AnoExpiracao = detalhePagamento.AnoExpiracao;
                    gatewayPatamento.MesExpiracao = detalhePagamento.MesExpiracao;
                    gatewayPatamento.Valor = carrinho.ValorTotalPedido;

                    gatewayPatamento.EfetuarPagamento();
                }

                InformarPagamento(carrinho);
            }

            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.Dinheiro))
            {
                InformarPagamento(carrinho);
            }
            #endregion

            #region Estoque
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
            #endregion

            #region Notificar Clientes
            if (notificarClienteEmail)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Email))
                {
                    using (var msg = new MailMessage("tiago.dantas@bancodaycoval.com.br", carrinho.Cliente.Email))
                    using (var smtp = new SmtpClient("servidor.smtp"))
                    {
                        msg.Subject = "Dados da sua compra";
                        msg.Body = $"Obrigado por efetuar sua compra conosco.";

                        smtp.Send(msg);
                    }
                }
            }

            if (notificarClienteSms)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Celular))
                {
                    var smsService = new SmsService();
                    smsService.Mensagem = "Obrigado por sua compra";
                    smsService.Celular = carrinho.Cliente.Celular;
                    smsService.EnviarSms();
                }
            }
            #endregion
        }

        private decimal CalcularValorTotalPedido(Produto produto)
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