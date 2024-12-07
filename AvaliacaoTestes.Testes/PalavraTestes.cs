using AvaliacaoTestes.Strings;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AvaliacaoTestes.Tests
{
    public class PalavraTestes
    {
        private readonly Palavra _stringOrdenador;

        public PalavraTestes()
        {
            _stringOrdenador = new Palavra();
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaDesordenada()
        {
            // Arrange
            var palavras = new List<string> { "banana", "Abacaxi", "caju" };
            var esperado = new List<string> { "Abacaxi", "banana", "caju" };

            // Act
            var resultado = _stringOrdenador.OrdenarStrings(palavras);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaJaOrdenada()
        {
            // Arrange
            var palavras = new List<string> { "Abacaxi", "banana", "caju" };

            // Act
            var resultado = _stringOrdenador.OrdenarStrings(palavras);

            // Assert
            Assert.Equal(palavras, resultado);
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaOrdenada_QuandoListaComDuplicadas()
        {
            // Arrange
            var palavras = new List<string> { "banana", "Abacaxi", "caju", "banana" };
            var esperado = new List<string> { "Abacaxi", "banana", "banana", "caju" };

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
            // Arrange
            var palavras = new List<string>();

            // Act
            var resultado = _stringOrdenador.OrdenarStrings(palavras);

            // Assert
            Assert.Empty(resultado);
        }
    }
}
