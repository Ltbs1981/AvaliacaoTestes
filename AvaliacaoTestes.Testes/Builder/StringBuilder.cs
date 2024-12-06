using Bogus;
using System;
using System.Collections.Generic;

namespace AvaliacaoTestes.Tests.Builder
{
    internal class StringBuilder
    {
        private List<string> _palavras;
        private Faker _faker;

        public StringBuilder()
        {
            _faker = new Faker();
            _palavras = new List<string>();
        }

        public StringBuilder ComPalavras(List<string> palavras = null)
        {
            if (palavras == null)
            {
                palavras = _faker.Lorem.Words(5).ToList();
            }

            _palavras = palavras;
            return this;
        }

        public StringBuilder ComPalavra(string palavra)
        {
            _palavras.Add(palavra);
            return this;
        }

        public List<string> Build()
        {
            return _palavras;
        }
    }
}
