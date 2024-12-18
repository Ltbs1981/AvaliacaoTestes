﻿using AvaliacaoTestes.Contratos.Repositorios;
using AvaliacaoTestes.Contratos.Servicos;
using AvaliacaoTestes.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Services
{
    public class EstudanteService : IEstudanteService
    {
        /* 
Declara um campo somente leitura (_estudanteRepository) que armazena 
uma instância da interface IEstudanteRepository. Este campo será 
usado para acessar os métodos definidos na interface, relacionados 
ao armazenamento e recuperação de dados dos estudantes.
*/
        private readonly IEstudanteRepository _estudanteRepository;

        public EstudanteService(IEstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        public List<string> ClassificarEstudantes(List<Estudante> estudantes)
        {
            if (estudantes == null)
            {
                throw new ArgumentNullException(nameof(estudantes), "A lista de estudantes não pode ser nula.");
            }

            if (!estudantes.Any())
            {
                return new List<string>();
            }

            return estudantes
                .OrderByDescending(e => e.Nota)
                .ThenBy(e => e.Nome)
                .Select(e => e.Nome)
                .ToList();
        }
    }
}
