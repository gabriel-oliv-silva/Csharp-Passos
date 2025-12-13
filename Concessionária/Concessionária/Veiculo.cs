using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concessionária
{
    public class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        private int ano;
        public int Ano
        {
            get { return ano; }
            set
            {
                if (value < 1890 || value > 2027)
                    throw new ArgumentException($"{value} não é um número válido para ano.");
                ano = value;
            }
        }

        private double valorBase;
        public double ValorBase
        {
            get { return valorBase; }
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{value} não é um número válido para preço.");
                valorBase = value;
            }
        }
        public List<Acessorio> Acessorios { get; set; }

        public Veiculo(string marca, string modelo, int ano, double valor)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            ValorBase = valor;
        }

        public double CalcularValorTotal()
        {
            double valor = 0;

            foreach (var item in Acessorios)
            {
                valor += item.Preco;
            }
            return ValorBase + valor;
        }

        public double AplicarDesconto(int percentual)
        {
            return CalcularValorTotal() - (CalcularValorTotal() * (percentual / 100));
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"- {Modelo} -\n\nMarca: {Marca}\nModelo: {Modelo}\nAno de fabricação: {Ano}");
            ListarAcessorios();
        }
        public void AdicionarAcessorio(Acessorio acessorio)
        {
            Acessorios ??= [];
            Acessorios.Add(acessorio);
        }
        public void ListarAcessorios()
        {
            int i = 0;
            foreach (var item in Acessorios)
            {
                i++;
                System.Console.WriteLine($"\n\t- Acessório {i} - \n {item}");
            }
        }

        public override string ToString()
        {
            return $"Marca: {Marca}\nModelo: {Modelo}\nAno de fabricação: {Ano}";
        }

    }
}