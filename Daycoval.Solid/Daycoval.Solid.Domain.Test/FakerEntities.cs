using Bogus;
using Bogus.Extensions.Brazil;
using Daycoval.Solid.Domain.Entidades;
using System.Collections.Generic;

namespace Daycoval.Solid.Domain.Test
{

    public class FakerEntities
    {
        public readonly Faker<Carrinho> fakerCarrinhoEntity;
        public readonly Faker<DetalhePagamento> fakerDetalhamentoPagamentoEntity;
        public FakerEntities()
        {
            fakerCarrinhoEntity = CarrinhoFaker();
            fakerDetalhamentoPagamentoEntity = DetalhamentoPagamentoFaker();
        }

        private Faker<Carrinho> CarrinhoFaker()
        {
            var faker = new Faker<Carrinho>();
            faker.RuleFor(m => m.Cliente, ClienteFaker());
            faker.RuleFor(m => m.Produtos, f => new List<ProdutoBase> { f.PickRandom(ProdutoAlimentoFaker().Generate()), f.PickRandom(ProdutoEletronicoFaker().Generate()), f.PickRandom(ProdutoSuperfulosFaker().Generate()) });

            return faker;
        }

        private Faker<DetalhePagamento> DetalhamentoPagamentoFaker()
        {
            var faker = new Faker<DetalhePagamento>();
            faker.RuleFor(m => m.FormaPagamento, f => f.PickRandom<FormaPagamento>());
            faker.RuleFor(m => m.NumeroCartao, f => f.Finance.CreditCardNumber());
            faker.RuleFor(m => m.NomeImpressoCartao, f => string.Format("{0} {1}", f.Person.FirstName , f.Person.LastName) );
            faker.RuleFor(m => m.MesExpiracao, f => 
                                                    { var date = f.Date.Future();
                                                        return date.Month;
                                                    });

            faker.RuleFor(m => m.AnoExpiracao, f =>
            {
                var date = f.Date.Future();
                return date.Year;
            });

            return faker;
        }

        private Faker<Cliente> ClienteFaker()
        {
            var faker = new Faker<Cliente>();
            faker.RuleFor(m => m.Nome, f => f.Person.FullName);
            faker.RuleFor(m => m.Cpf, f => f.Person.Cpf(true));
            faker.RuleFor(m => m.Email, f => f.Person.Email);
            faker.RuleFor(m => m.Celular, f => f.Person.Phone);

            return faker;
        }

 
        private Faker<ProdutoAlimento> ProdutoAlimentoFaker()
        {
            var faker = new Faker<ProdutoAlimento>();
            faker.RuleFor(m => m.Descricao, f => f.Lorem.Sentences(1));
            faker.RuleFor(m => m.Quantidade, f => f.Random.Int(1, 100));
            faker.RuleFor(m => m.Valor, f => f.Finance.Amount(1, 1000));

            return faker;
        }

        private Faker<ProdutoEletronico> ProdutoEletronicoFaker()
        {
            var faker = new Faker<ProdutoEletronico>();
            faker.RuleFor(m => m.Descricao, f => f.Lorem.Sentences(1));
            faker.RuleFor(m => m.Quantidade, f => f.Random.Int(1, 100));
            faker.RuleFor(m => m.Valor, f => f.Finance.Amount(1, 1000));

            return faker;
        }

        private Faker<ProdutoSuperfulos> ProdutoSuperfulosFaker()
        {
            var faker = new Faker<ProdutoSuperfulos>();
            faker.RuleFor(m => m.Descricao, f => f.Lorem.Sentences(1));
            faker.RuleFor(m => m.Quantidade, f => f.Random.Int(1, 100));
            faker.RuleFor(m => m.Valor, f => f.Finance.Amount(1, 1000));

            return faker;
        }

    }
}
