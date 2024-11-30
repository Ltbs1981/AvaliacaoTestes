using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatorialTestes
{
    internal class Fatorando
    {
        public int NumeroInicial { get; set; }
        public int Resultado { get; set; }

        public int FatorarNumeros(int numInicial)
        {
            NumeroInicial = numInicial;
            Resultado = 1;

            for (int i = numInicial; i > 1; i--)
            {
                Resultado *= i;
            }

            return Resultado;
        }
    }
}
