using AvaliacaoTestes.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Testes
{
    public class NumeroTestes
    {
        [Fact]
        public void VerificarSequencia_DeveRetornarCrescente_QuandoSequenciaCrescente()
        {
            // Arrange
            var numeros = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var resultado = Numero.VerificarSequencia(numeros);

            // Assert
            Assert.Equal("Crescente", resultado);
        }

        [Fact]
        public void VerificarSequencia_DeveRetornarDecrescente_QuandoSequenciaDecrescente()
        {
            // Arrange
            var numeros = new List<int> { 5, 4, 3, 2, 1 };

            // Act
            var resultado = Numero.VerificarSequencia(numeros);

            // Assert
            Assert.Equal("Decrescente", resultado);
        }

        [Fact]
        public void VerificarSequencia_DeveRetornarNenhum_QuandoSequenciaDesordenada()
        {
            // Arrange
            var numeros = new List<int> { 1, 3, 2, 4, 5 };

            // Act
            var resultado = Numero.VerificarSequencia(numeros);

            // Assert
            Assert.Equal("Nenhum", resultado);
        }

        [Fact]
        public void VerificarSequencia_DeveRetornarNenhum_QuandoListaComApenasUmNumero()
        {
            // Arrange
            var numeros = new List<int> { 1 };

            // Act
            var resultado = Numero.VerificarSequencia(numeros);

            // Assert
            Assert.Equal("Nenhum", resultado);
        }

        [Fact]
        public void VerificarSequencia_DeveLancarArgumentNullException_QuandoListaForNula()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Numero.VerificarSequencia(null));
        }

        [Fact]
        public void VerificarSequencia_DeveRetornarNenhum_QuandoListaVazia()
        {
            // Arrange
            var numeros = new List<int>();

            // Act
            var resultado = Numero.VerificarSequencia(numeros);

            // Assert
            Assert.Equal("Nenhum", resultado);
        }
    }
}