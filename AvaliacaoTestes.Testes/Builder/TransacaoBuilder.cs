using AvaliacaoTestes.Bank;
using Bogus;

namespace AvaliacaoTestes.Testes.Builder
{
    public class TransacaoBuilder
    {
        private List<Transacao> _transacoes;
        private Faker _faker;

        public TransacaoBuilder()
        {
            _faker = new Faker();
            _transacoes = new List<Transacao>();
        }

        public TransacaoBuilder ComTransacoes(List<Transacao> transacoes = null)
        {
            if (transacoes == null)
            {
                transacoes = new List<Transacao>
            {
                new Transacao { Cliente = _faker.Person.FirstName, Valor = _faker.Finance.Amount() },
                new Transacao { Cliente = _faker.Person.FirstName, Valor = _faker.Finance.Amount() }
            };
            }

            _transacoes = transacoes;
            return this;
        }

        public TransacaoBuilder ComTransacao(string cliente, decimal valor)
        {
            _transacoes.Add(new Transacao { Cliente = cliente, Valor = valor });
            return this;
        }

        public List<Transacao> Build()
        {
            return _transacoes;
        }
    }
}