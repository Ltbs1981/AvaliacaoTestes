using AvaliacaoTestes.Products;
using Bogus;

namespace AvaliacaoTestes.Testes.Mother
{
    public static class ProdutoMotherObject
    {
        public static List<Produto> ObterProdutos(int quantidade)
        {
            var faker = new Faker<Produto>()
                .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                .RuleFor(p => p.Categoria, f => f.Commerce.Categories(1)[0])
                .RuleFor(p => p.Preco, f => f.Random.Decimal(1, 100)); // Corrigido para gerar decimais

            return faker.Generate(quantidade);
        }

        public static List<Produto> ObterProdutosSemCategoria(int quantidade)
        {
            var faker = new Faker<Produto>()
                .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                .RuleFor(p => p.Categoria, f => string.Empty) // Corrigido para gerar categoria vazia
                .RuleFor(p => p.Preco, f => f.Random.Decimal(1, 100)); // Corrigido para gerar decimais

            return faker.Generate(quantidade);
        }
    }
}
