using AvaliacaoTestes.Strings;
using Bogus;

namespace AvaliacaoTestes.Tests
{
    /*
Classe de testes unitários para a classe Palavra.
Contém métodos de teste que verificam a funcionalidade de ordenação de strings.
Usa a biblioteca Faker para gerar dados fictícios para os testes.
*/
    public class PalavraTestes
    {
        private readonly Palavra _palavra;
        private readonly Faker _faker;

        /*
        Construtor da classe PalavraTestes.
        Inicializa o campo _palavra com uma nova instância da classe Palavra.
        Inicializa o campo _faker com uma nova instância da classe Faker.
        */
        public PalavraTestes()
        {
            _palavra = new Palavra();
            _faker = new Faker();
        }

        /*
        Método de teste que verifica se a função OrdenarStrings retorna uma lista ordenada
        quando a lista de entrada está desordenada.
        Usa a anotação [Theory] e [InlineData] para testar com diferentes quantidades de palavras.
        */
        [Theory]
        [InlineData(5)]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaDesordenada(int quantidadePalavras)
        {
            // Arrange
            var palavras = _faker.Lorem.Words(quantidadePalavras);
            var esperado = new List<string>(palavras);
            esperado.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));

            // Act
            var resultado = _palavra.OrdenarStrings(new List<string>(palavras));

            // Assert
            Assert.Equal(esperado, resultado);
        }

        /*
        Método de teste que verifica se a função OrdenarStrings retorna a mesma lista
        quando a lista de entrada já está ordenada.
        Usa a anotação [Theory] e [InlineData] para testar com diferentes quantidades de palavras.
        */
        [Theory]
        [InlineData(3)]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaJaOrdenada(int quantidadePalavras)
        {
            // Arrange
            var palavras = new List<string>(_faker.Lorem.Words(quantidadePalavras));
            palavras.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));

            // Act
            var resultado = _palavra.OrdenarStrings(palavras);

            // Assert
            Assert.Equal(palavras, resultado);
        }

        /*
        Método de teste que verifica se a função OrdenarStrings retorna uma lista ordenada
        quando a lista de entrada contém strings duplicadas.
        Usa a anotação [Theory] e [InlineData] para testar com diferentes quantidades de palavras.
        */
        [Theory]
        [InlineData(5)]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaComDuplicadas(int quantidadePalavras)
        {
            // Arrange
            var palavras = new List<string>(_faker.Lorem.Words(quantidadePalavras));
            palavras.AddRange(_faker.Lorem.Words(quantidadePalavras));
            var esperado = new List<string>(palavras);
            esperado.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));

            // Act
            var resultado = _palavra.OrdenarStrings(palavras);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        /*
        Método de teste que verifica se a função OrdenarStrings retorna uma lista vazia
        quando a lista de entrada é nula.
        Usa a anotação [Fact] para um único teste específico.
        */
        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoEntradaNula()
        {
            // Act
            var resultado = _palavra.OrdenarStrings(null);

            // Assert
            Assert.Empty(resultado);
        }

        /*
        Método de teste que verifica se a função OrdenarStrings retorna uma lista vazia
        quando a lista de entrada é vazia.
        Usa a anotação [Fact] para um único teste específico.
        */
        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoListaVazia()
        {
            // Act
            var resultado = _palavra.OrdenarStrings(new List<string>());

            // Assert
            Assert.Empty(resultado);
        }
    }
}