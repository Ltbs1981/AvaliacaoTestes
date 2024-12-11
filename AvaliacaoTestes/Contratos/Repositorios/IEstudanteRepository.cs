using AvaliacaoTestes.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Contratos.Repositorios
{
    public interface IEstudanteRepository
    {
        List<Estudante> ObterTodos();
    }
}
