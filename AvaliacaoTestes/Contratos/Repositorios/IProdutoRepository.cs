using AvaliacaoTestes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Contratos.Repositorios
{
    public interface IProdutoRepository
    {
        List<Produto> ObterTodos();
    }
}