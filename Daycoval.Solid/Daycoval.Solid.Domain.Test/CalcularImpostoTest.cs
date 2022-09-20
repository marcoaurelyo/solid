using Daycoval.Solid.Domain.Impostos;
using Daycoval.Solid.Domain.Impostos.TipoProduto;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Daycoval.Solid.Domain.Test
{
    public class CalcularImpostoTest
    {
        [Fact]
        public void ValidImposto_AlimentoImposto_ReturnSucess()
        {
            var valorProduto = 100;
            var resultExpected = 5;
            var alimentoImposto = new AlimentoImposto();

            //Act
            var result = alimentoImposto.CalcularImposto(valorProduto);

            //Assert
            Assert.Equal(resultExpected, result);
        }

        [Fact]
        public void ValidImposto_EletroncioImposto_ReturnSucess()
        {
            var valorProduto = 100;
            var resultExpected = 15;
            var alimentoImposto = new EletronicoImposto();

            //Act
            var result = alimentoImposto.CalcularImposto(valorProduto);

            //Assert
            Assert.Equal(resultExpected, result);
        }

        [Fact]
        public void ValidImposto_SuperfulosImposto_ReturnSucess()
        {
            var valorProduto = 100;
            var resultExpected = 20;
            var alimentoImposto = new SuperfulosImposto();

            //Act
            var result = alimentoImposto.CalcularImposto(valorProduto);

            //Assert
            Assert.Equal(resultExpected, result);
        }

 
    }
}
