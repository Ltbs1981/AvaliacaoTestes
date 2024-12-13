
using System;
using System.Collections.Generic;
using System.Linq;

//namespace OrdenacaoTestes
namespace AvaliacaoTestes.Strings
{
    public class Palavra
    {
        /*
Método que ordena uma lista de strings alfabeticamente, ignorando diferenças de maiúsculas e minúsculas. 
Primeiramente, verifica se a lista de palavras é nula ou vazia e retorna uma nova lista vazia nesses casos. 
Caso contrário, utiliza a função OrderBy com o comparador StringComparer.OrdinalIgnoreCase para ordenar 
as palavras de forma case insensitive e, em seguida, converte o resultado em uma lista.
*/
        public List<string> OrdenarStrings(List<string> palavras)
        {
            if (palavras == null || !palavras.Any())
            {
                return new List<string>();
            }

            return palavras.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
        }
    }
}
