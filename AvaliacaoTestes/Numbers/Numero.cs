using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Numbers
{
    public class Numero
    {
        public static string VerificarSequencia(List<int> numeros)
        {
            if (numeros == null)
            {
                throw new ArgumentNullException(nameof(numeros), "A lista de números não pode ser nula.");
            }

            if (numeros.Count < 2)
            {
                return "Nenhum";
            }

            bool crescente = true;
            bool decrescente = true;

            for (int i = 1; i < numeros.Count; i++)
            {
                if (numeros[i] > numeros[i - 1])
                {
                    decrescente = false;
                }
                if (numeros[i] < numeros[i - 1])
                {
                    crescente = false;
                }
            }

            if (crescente)
            {
                return "Crescente";
            }

            if (decrescente)
            {
                return "Decrescente";
            }

            return "Nenhum";
        }
    }
}
