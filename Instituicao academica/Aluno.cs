using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_05
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Serie { get; set; }
        public string Matricula { get; set; }

        public Aluno(string nome, string serie, string matricula)
        {
            Nome = nome;
            Serie = serie;
            Matricula = matricula;
        }
        public override string ToString()
        {
            return $"\nNome: {Nome}\nSerie: {Serie} ano\nMatrícula:{Matricula}\n";
        }
    }
}