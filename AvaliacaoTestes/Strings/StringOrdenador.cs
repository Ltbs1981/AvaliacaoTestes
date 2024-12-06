//namespace AvaliacaoTestes.Strings
using System;
using System.Collections.Generic;
using System.Linq;

//namespace OrdenacaoTestes
namespace AvaliacaoTestes.Strings
{
    public class StringOrdenador
    {
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
