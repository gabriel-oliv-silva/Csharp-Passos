using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_05
{
    public class Professor
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }

        public Professor(string nome, string titulo)
        {
            Nome = nome;
            Titulo = titulo;
        }

        public override string ToString()
        {
            return $"\nNome: {Nome}\nTitulo: {Titulo}\n";
        }
    }
}