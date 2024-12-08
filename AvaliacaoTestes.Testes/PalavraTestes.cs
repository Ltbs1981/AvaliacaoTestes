using AvaliacaoTestes.Strings;
using Bogus;

namespace AvaliacaoTestes.Tests
{
    public class PalavraTestes
    {
        private readonly Palavra _stringOrdenador;
        private readonly Faker _faker;

        public PalavraTestes()
        {
            _stringOrdenador = new Palavra();
            _faker = new Faker();
        }

        [Theory]
        [InlineData(5)]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaDesordenada(int quantidadePalavras)
        {
            // Arrange
            var palavras = _faker.Lorem.Words(quantidadePalavras);
            var esperado = new List<string>(palavras);
            esperado.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));

            // Act
            var resultado = _stringOrdenador.OrdenarStrings(new List<string>(palavras));

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData(3)]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaJaOrdenada(int quantidadePalavras)
        {
            // Arrange
            var palavras = new List<string>(_faker.Lorem.Words(quantidadePalavras));
            palavras.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));

            // Act
            var resultado = _stringOrdenador.OrdenarStrings(palavras);

            // Assert
            Assert.Equal(palavras, resultado);
        }

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
            var resultado = _stringOrdenador.OrdenarStrings(palavras);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoEntradaNula()
        {
            // Act
            var resultado = _stringOrdenador.OrdenarStrings(null);

            // Assert
            Assert.Empty(resultado);
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoListaVazia()
        {
            // Act
            var resultado = _stringOrdenador.OrdenarStrings(new List<string>());

            // Assert
            Assert.Empty(resultado);
        }
    }
}
