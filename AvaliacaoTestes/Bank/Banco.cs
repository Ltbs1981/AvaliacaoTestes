﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTestes.Bank
{
    public class Banco
    {
        public Dictionary<string, decimal> CalcularSaldoPorCliente(List<Transacao> transacoes)
        {
            if (transacoes == null || !transacoes.Any())
            {
                return new Dictionary<string, decimal>();
            }

            return transacoes
                .Where(t => t.Valor != 0)
                .GroupBy(t => t.Cliente)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Valor));
        }
    }
}
