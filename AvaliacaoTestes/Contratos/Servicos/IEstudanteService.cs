using AvaliacaoTestes.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Contratos.Servicos
{
    public interface IEstudanteService
    {
        List<string> ClassificarEstudantes(List<Estudante> estudantes);
    }
}
