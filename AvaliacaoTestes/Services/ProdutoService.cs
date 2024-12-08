using AvaliacaoTestes.Contratos.Repositorios;
using AvaliacaoTestes.Contratos.Servicos;
using AvaliacaoTestes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Dictionary<string, List<Produto>> AgruparPorCategoria(List<Produto> produtos)
        {
            if (produtos == null)
            {
                throw new ArgumentNullException(nameof(produtos), "A lista de produtos não pode ser nula.");
            }

            if (!produtos.Any())
            {
                throw new ArgumentException("A lista de produtos não pode estar vazia.", nameof(produtos));
            }

            return produtos
                .Where(p => !string.IsNullOrEmpty(p.Categoria))
                .GroupBy(p => p.Categoria)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}