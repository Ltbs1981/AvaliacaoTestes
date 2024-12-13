using System;

namespace FatorialTestes
{
    public class Fatorando
    {
        /*
Método que calcula o fatorial de um número.
1. Verifica se o número é negativo e lança uma exceção, já que números negativos não têm fatorial.
2. Retorna 1 se o número for zero, pois o fatorial de zero é definido como 1.
3. Calcula o fatorial multiplicando todos os números de n a 1.
4. Usa um loop para multiplicar os valores decrementando de i a cada iteração.
5. Retorna o resultado final do fatorial.
*/
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

