using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Aula_04
{
    public class Evento
    {

        public string Nome { get; set; }
        public double Valor { get; set; } = 0;

        public string Local { get; set; }

        private List<Pessoas> Pessoa;

        public List<Pessoas> Pessoas
        {
            get { return Pessoa; }
            set
            {
                if (value.Count() < 3)
                    Pessoa = value;
                else
                    throw new ArgumentException("Limite atingido!");
            }
        }

        public Evento(string Nome, string Local)
        {
            this.Nome = Nome;
            this.Local = Local;
            this.Pessoa = new List<Pessoas>();
        }

    }
}