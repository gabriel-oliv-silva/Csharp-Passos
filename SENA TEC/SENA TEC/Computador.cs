using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SENA_TEC
{
    public class Computador
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Processador { get; set; }

        private double ValorBase;
        public double Valor
        {
            get { return ValorBase; }
            set
            {
                if (value >= 0) ValorBase = value;
                else throw new ArgumentException("Valor inválido!");
            }
        }
        public List<Periferico> Perifericos { get; set; }

        public Computador(string marca, string modelo, string processador, double valorBase)
        {
            Marca = marca;
            Modelo = modelo;
            Processador = processador;
            ValorBase = valorBase;
        }

        public void AdicionarPeriferico(Periferico periferico)
        {
            Perifericos ??= new List<Periferico>();
            Perifericos.Add(periferico);

        }

        public Double CalcularValorTotal()
        {
            double valorPerifericos = 0;

            foreach (var item in Perifericos)
                valorPerifericos += item.Precos;

            return ValorBase + valorPerifericos;
        }

        public void AplicarDesconto(double percentual)
        {
            System.Console.WriteLine($"\nAplicando desconto de {percentual}%...");
            System.Console.WriteLine($"Valor com desconto: R${CalcularValorTotal() - (CalcularValorTotal() * (percentual / 100))}");
        }
        public void ListarPerifericos()
        {
            foreach (var item in Perifericos)
            {
                Console.WriteLine(item);

            }
        }
        public void RemoverPeriferico(string marca)
        {
            bool encontrado = false;
            foreach (var item in Perifericos)
            {
                if (string.Equals(item.Marca, marca, StringComparison.OrdinalIgnoreCase))
                {
                    Perifericos.Remove(item);
                    encontrado = true;
                }
            }
            if (encontrado == false)
                throw new ArgumentException("Objeto não encontrado!");
        }
        public void Comparar(Computador outro)
        {
            if (outro.CalcularValorTotal() > CalcularValorTotal())
                System.Console.WriteLine($"O computador do modelo {outro.Modelo} é mais caro");
            else
                System.Console.WriteLine($"O computador do modelo {Modelo} é mais caro");
        }
        public void ExibirDetalhes()
        {

            Console.WriteLine($"- Computador -\n\nMarca: {Marca}\nModelo: {Modelo}\nProcessador: {Processador}\nValor Base: R${ValorBase}");
            ListarPerifericos();

        }

    }
}
