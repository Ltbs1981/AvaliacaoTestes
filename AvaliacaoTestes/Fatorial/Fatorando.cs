using System;

namespace FatorialTestes
{
    public class Fatorando
    {
        public int CalcularFatorial(int numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("O número não pode ser negativo.");
            }

            if (numero == 0)
            {
                return 1;
            }

            int resultado = 1;

            for (int i = numero; i > 1; i--)
            {
                resultado *= i;
            }

            return resultado;
        }
    }
}

