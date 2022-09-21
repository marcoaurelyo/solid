using System.Collections.Generic;

namespace Daycoval.Solid.Domain.Entidades
{
    public class Carrinho
    {

        private decimal _valorTotalPedido;
        public decimal ValorTotalPedido { get { return _valorTotalPedido; } }
        public List<ProdutoBase> Produtos { get; set; }
        public Cliente Cliente { get; set; }
        public bool FoiPago { get; set; }
        public bool FoiEntregue { get; set; }

        public void CalcularValorTotalPedido()
        {
            Produtos.ForEach(x => _valorTotalPedido += x.CalularValorTotalProduto());
        }

        public void RealizaCalculoImposto()
        {
            Produtos.ForEach(x => x.ValorImposto = x.RealizaCalculoImposto());
        }
    }
}