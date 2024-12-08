using AvaliacaoTestes.Contratos.Repositorios;
using AvaliacaoTestes.Contratos.Servicos;
using AvaliacaoTestes.Products;
using AvaliacaoTestes.Services;
using AvaliacaoTestes.Testes.Mother;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Testes
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly IProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object);
        }

        // Dados de teste usando MemberData e IEnumerable
        public static IEnumerable<object[]> DadosTesteAgrupamento
        {
            get
            {
                // Teste para múltiplas categorias
                var produtos = ProdutoMotherObject.ObterProdutos(10);
                var esperado = produtos
                    .Where(p => !string.IsNullOrEmpty(p.Categoria))
                    .GroupBy(p => p.Categoria)
                    .ToDictionary(g => g.Key, g => g.ToList());

                yield return new object[]
                {
                    produtos,
                    esperado
                };

                // Teste para produtos sem categoria
                yield return new object[]
                {
                    ProdutoMotherObject.ObterProdutosSemCategoria(5),
                    new Dictionary<string, List<Produto>>()
                };
            }
        }

        [Theory]
        [MemberData(nameof(DadosTesteAgrupamento))]
        public void AgruparPorCategoria_DeveRetornarProdutosAgrupadosPorCategoria(List<Produto> produtos, Dictionary<string, List<Produto>> esperado)
        {
            // Arrange
            _produtoRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(produtos);

            // Act
            var resultado = _produtoService.AgruparPorCategoria(produtos);

            // Assert
            Assert.Equal(esperado.Count, resultado.Count);
            foreach (var categoria in esperado.Keys)
            {
                Assert.True(resultado.ContainsKey(categoria));
                Assert.Equal(esperado[categoria], resultado[categoria]);
            }
        }

        [Fact]
        public void AgruparPorCategoria_DeveLancarArgumentNullException_QuandoListaForNula()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _produtoService.AgruparPorCategoria(null));
        }

        [Fact]
        public void AgruparPorCategoria_DeveLancarArgumentException_QuandoListaForVazia()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _produtoService.AgruparPorCategoria(new List<Produto>()));
        }
    }
}