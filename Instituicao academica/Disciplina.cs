using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_05
{
    public class Disciplina
    {
        public string Nome { get; set; }
    
        public int Ch { get; set; }

        public Disciplina(string Nome, int Ch)
        {
            this.Nome = Nome;
            this.Ch = Ch;
        }
        public override string ToString()
        {
            return $"\nNome: {Nome}\nCarga horária: {Ch} horas\n";
        }
    }
}