using AvaliacaoTestes.Products;

namespace AvaliacaoTestes.Contratos.Servicos
{
    public interface IProdutoService
    {
        Dictionary<string, List<Produto>> AgruparPorCategoria(List<Produto> produtos);
    }
}
