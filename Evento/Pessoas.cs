using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_04
{
    public class Pessoas
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public string Endereco { get; set; }

        public Pessoas(string Nome, string Endereco, int Idade)
        {
            this.Nome = Nome;
            this.Idade = Idade;
            this.Endereco = Endereco;
        }

    }
}