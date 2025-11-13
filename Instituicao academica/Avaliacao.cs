using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_05
{
    public class Avaliacao
    {
        public string Nome { get; set; }
        public double Nota { get; set; }
        public string Serie { get; set; }
        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }
        public Disciplina Disciplina { get; set; }
        public Avaliacao(string Nome, double Nota, string Serie, Aluno aluno, Professor professor, Disciplina disc)
        {
            if (!aluno.Serie.Equals(Serie))
                throw new ArgumentException("O aluno não está nesta disciplina!");
            else
                Aluno = aluno;

            this.Nome = Nome;
            this.Nota = Nota;
            this.Serie = Serie;
            Professor = professor;
            Disciplina = disc;
        }

        public override string ToString()
        {
            return $"\t�Resumo\n\nNome: {Nome}\nNota: {Nota}\nSerie: {Serie} ano\n\n\t----  Aluno  -----\n{Aluno}\n\t----  Professor  ----\n{Professor}\n\t----  Disciplina  ----\n{Disciplina}";
        }

    }
}