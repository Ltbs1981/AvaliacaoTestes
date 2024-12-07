using AvaliacaoTestes.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Testes
{
    public class BancoTestes
    {
        private readonly Banco _banco;

        public BancoTestes()
        {
            _banco = new Banco();
        }

        public static IEnumerable<object[]> TransacoesBasicas
        {
            get
            {
                yield return new object[]
                {
                new List<Transacao>
                {
                    new Transacao { Cliente = "Luciano", Valor = 100 },
                    new Transacao { Cliente = "Bela", Valor = -50 },
                    new Transacao { Cliente = "Luciano", Valor = -20 },
                    new Transacao { Cliente = "Bela", Valor = 200 }
                },
                new Dictionary<string, decimal>
                {
                    { "Luciano", 80 },
                    { "Bela", 150 }
                }
                };
            }
        }

        public static IEnumerable<object[]> TransacoesNulasOuVazias
        {
            get
            {
                yield return new object[] { null, new Dictionary<string, decimal>() };
                yield return new object[] { new List<Transacao>(), new Dictionary<string, decimal>() };
            }
        }

        public static IEnumerable<object[]> TransacoesClientesUnicos
        {
            get
            {
                yield return new object[]
                {
                new List<Transacao>
                {
                    new Transacao { Cliente = "Luciano", Valor = 100 },
                    new Transacao { Cliente = "Luciano", Valor = 200 },
                    new Transacao { Cliente = "Luciano", Valor = -50 }
                },
                new Dictionary<string, decimal>
                {
                    { "Luciano", 250 }
                }
                };
            }
        }

        public static IEnumerable<object[]> TransacoesValorZero
        {
            get
            {
                yield return new object[]
                {
                new List<Transacao>
                {
                    new Transacao { Cliente = "Luciano", Valor = 100 },
                    new Transacao { Cliente = "Luciano", Valor = 0 },
                    new Transacao { Cliente = "Bela", Valor = 200 }
                },
                new Dictionary<string, decimal>
                {
                    { "Luciano", 100 },
                    { "Bela", 200 }
                }
                };
            }
        }

        public static IEnumerable<object[]> TransacoesSaldoNegativo
        {
            get
            {
                yield return new object[]
                {
                new List<Transacao>
                {
                    new Transacao { Cliente = "Luciano", Valor = -100 },
                    new Transacao { Cliente = "Bela", Valor = -200 },
                    new Transacao { Cliente = "Luciano", Valor = 50 }
                },
                new Dictionary<string, decimal>
                {
                    { "Luciano", -50 },
                    { "Bela", -200 }
                }
                };
            }
        }

        [Theory]
        [MemberData(nameof(TransacoesBasicas))]
        public void CalcularSaldoPorCliente_DeveRetornarSaldoTotalPorCliente(List<Transacao> transacoes, Dictionary<string, decimal> esperado)
        {
            // Act
            var resultado = _banco.CalcularSaldoPorCliente(transacoes);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [MemberData(nameof(TransacoesNulasOuVazias))]
        public void CalcularSaldoPorCliente_DeveRetornarDicionarioVazio_QuandoTransacoesNulasOuVazias(List<Transacao> transacoes, Dictionary<string, decimal> esperado)
        {
            // Act
            var resultado = _banco.CalcularSaldoPorCliente(transacoes);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [MemberData(nameof(TransacoesClientesUnicos))]
        public void CalcularSaldoPorCliente_DeveRetornarSaldoTotalPorClienteUnico(List<Transacao> transacoes, Dictionary<string, decimal> esperado)
        {
            // Act
            var resultado = _banco.CalcularSaldoPorCliente(transacoes);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [MemberData(nameof(TransacoesValorZero))]
        public void CalcularSaldoPorCliente_DeveIgnorarTransacoesDeValorZero(List<Transacao> transacoes, Dictionary<string, decimal> esperado)
        {
            // Act
            var resultado = _banco.CalcularSaldoPorCliente(transacoes);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [MemberData(nameof(TransacoesSaldoNegativo))]
        public void CalcularSaldoPorCliente_DeveCalcularSaldoNegativo(List<Transacao> transacoes, Dictionary<string, decimal> esperado)
        {
            // Act
            var resultado = _banco.CalcularSaldoPorCliente(transacoes);

            // Assert
            Assert.Equal(esperado, resultado);
        }
    }
}