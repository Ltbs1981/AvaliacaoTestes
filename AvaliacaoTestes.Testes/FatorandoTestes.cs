﻿using System;
using Xunit;

namespace FatorialTestes.Tests
{
    public class FatorandoTestes
    {
        /*
Declaração do campo _fatorando como somente leitura.
Este campo armazena uma instância da classe Fatorando.
*/
        private readonly Fatorando _fatorando;
        /*
Construtor da classe FatorandoTestes.
Inicializa o campo _fatorando com uma nova instância da classe Fatorando.
*/
        public FatorandoTestes()
        {
            _fatorando = new Fatorando();
        }

        [Fact]
        public void CalcularFatorial_DeveRetornar120_QuandoNumeroFor5()
        {
            // Arrange
            int numero = 5;

            // Act
            int resultado = _fatorando.CalcularFatorial(numero);

            // Assert
            Assert.Equal(120, resultado);
        }

        [Fact]
        public void CalcularFatorial_DeveRetornar6_QuandoNumeroFor3()
        {
            // Arrange
            int numero = 3;

            // Act
            int resultado = _fatorando.CalcularFatorial(numero);

            // Assert
            Assert.Equal(6, resultado);
        }

        [Fact]
        public void CalcularFatorial_DeveRetornar1_QuandoNumeroFor0()
        {
            // Arrange
            int numero = 0;

            // Act
            int resultado = _fatorando.CalcularFatorial(numero);

            // Assert
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void CalcularFatorial_DeveLancarArgumentException_QuandoNumeroForNegativo()
        {
            // Arrange
            int numero = -1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _fatorando.CalcularFatorial(numero));
        }
    }
}
