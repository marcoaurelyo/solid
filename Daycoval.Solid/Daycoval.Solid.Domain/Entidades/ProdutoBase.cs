using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Entidades
{
    public abstract class ProdutoBase
    {
        private TipoProduto _tipoProduto;
        public ProdutoBase()
        {
        }
        public ProdutoBase(TipoProduto tipoProduto)
        {
            _tipoProduto = tipoProduto;
        }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorImposto { get; set; }
        public TipoProduto TipoProduto { get { return _tipoProduto; } }
        public abstract decimal RealizaCalculoImposto();
        public abstract decimal CalularValorTotalProduto();

    }
}
