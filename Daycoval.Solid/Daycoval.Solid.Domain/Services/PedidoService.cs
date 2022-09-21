using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Services.Estoque;
using Daycoval.Solid.Domain.Services.Impostos;
using Daycoval.Solid.Domain.Services.Notificar;
using Daycoval.Solid.Domain.Services.Pagamento;
using System.Runtime.InteropServices;

namespace Daycoval.Solid.Domain.Services
{
    public class PedidoService
    {
        IImpostoFactory _impostoFactory;
        IPagamento _pagamento;
        IEstoque _estoqueService;
        INotificar _notificar;
   
        public PedidoService( IImpostoFactory impostoFactory,
                             IPagamento pagamento,
                             IEstoque estoqueService,
                             INotificar notificar)
        {
            this._estoqueService = estoqueService;
            this._impostoFactory = impostoFactory;
            this._pagamento = pagamento;
            this._notificar = notificar;
        }

        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            //Não existe mas nenhuma implementação concreta de imposto na classe PedidoService
            IImposto imposto = _impostoFactory.GetObjectImposto();
            carrinho.Produtos.ForEach(x => x.ValorImposto = imposto.RealizaCalculo(x));

            CalcularValorTotalPedido(carrinho);

            if (_pagamento.RealizarPagamento(detalhePagamento, carrinho.ValorTotalPedido))
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

            if (carrinho.Cliente != null)
                _notificar.RealizarNotificacao(carrinho.Cliente, notificarClienteEmail, notificarClienteSms);
        }

        public void CalcularValorTotalPedido(Carrinho carrinho)
        {
            carrinho.Produtos.ForEach(x => carrinho.ValorTotalPedido += CalularValorTotalProduto(x));
        }
        private decimal CalularValorTotalProduto(Produto produto)
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