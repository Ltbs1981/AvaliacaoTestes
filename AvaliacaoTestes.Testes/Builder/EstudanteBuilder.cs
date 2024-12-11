using AvaliacaoTestes.Students;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Testes.Builder
{
    public static class EstudanteBuilder
    {
        public static List<Estudante> ObterEstudantes(int quantidade)
        {
            var faker = new Faker<Estudante>()
                .RuleFor(e => e.Nome, f => f.Person.FullName)
                .RuleFor(e => e.Nota, f => f.Random.Decimal(0, 10));

            return faker.Generate(quantidade);
        }
    }
}
