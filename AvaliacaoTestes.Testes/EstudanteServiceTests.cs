using AvaliacaoTestes.Contratos.Repositorios;
using AvaliacaoTestes.Contratos.Servicos;
using AvaliacaoTestes.Services;
using AvaliacaoTestes.Students;
using AvaliacaoTestes.Testes.Builder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Testes
{
    public class EstudanteServiceTests
    {
        private readonly Mock<IEstudanteRepository> _estudanteRepositoryMock;
        private readonly IEstudanteService _estudanteService;

        public EstudanteServiceTests()
        {
            _estudanteRepositoryMock = new Mock<IEstudanteRepository>();
            _estudanteService = new EstudanteService(_estudanteRepositoryMock.Object);
        }

        [Fact]
        public void ClassificarEstudantes_DeveRetornarListaOrdenadaPorNotaDecrescente()
        {
            // Arrange
            var estudantes = EstudanteBuilder.ObterEstudantes(5);
            _estudanteRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(estudantes);

            // Act
            var resultado = _estudanteService.ClassificarEstudantes(estudantes);

            // Assert
            var esperado = estudantes.OrderByDescending(e => e.Nota).ThenBy(e => e.Nome).Select(e => e.Nome).ToList();
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void ClassificarEstudantes_DeveLancarArgumentNullException_QuandoListaForNula()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _estudanteService.ClassificarEstudantes(null));
        }

        [Fact]
        public void ClassificarEstudantes_DeveRetornarListaVazia_QuandoListaForVazia()
        {
            // Act
            var resultado = _estudanteService.ClassificarEstudantes(new List<Estudante>());

            // Assert
            Assert.Empty(resultado);
        }

        [Fact]
        public void ClassificarEstudantes_DeveRetornarListaOrdenadaPorNome_QuandoNotasForemIguais()
        {
            // Arrange
            var estudantes = new List<Estudante>
        {
            new Estudante { Nome = "Ana", Nota = 8.5M },
            new Estudante { Nome = "Carlos", Nota = 9.0M },
            new Estudante { Nome = "Bruno", Nota = 9.0M },
        };
            _estudanteRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(estudantes);

            // Act
            var resultado = _estudanteService.ClassificarEstudantes(estudantes);

            // Assert
            var esperado = estudantes.OrderByDescending(e => e.Nota).ThenBy(e => e.Nome).Select(e => e.Nome).ToList();
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void ClassificarEstudantes_DeveLidarComNotasNegativasEExtremas()
        {
            // Arrange
            var estudantes = new List<Estudante>
        {
            new Estudante { Nome = "Ana", Nota = -1.0M },
            new Estudante { Nome = "Carlos", Nota = 15.0M },
            new Estudante { Nome = "Bruno", Nota = 10.0M },
        };
            _estudanteRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(estudantes);

            // Act
            var resultado = _estudanteService.ClassificarEstudantes(estudantes);

            // Assert
            var esperado = estudantes.OrderByDescending(e => e.Nota).ThenBy(e => e.Nome).Select(e => e.Nome).ToList();
            Assert.Equal(esperado, resultado);
        }
    }
}
