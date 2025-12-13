using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_de_Produtos_Eletrônicos
{
    public class Notebook : Produto
    {
        public Notebook(double tamanhoTela, string processador, string nome, string marca, string codigo, double preco) : base(nome, marca, codigo, preco)
        {
            TamanhoTela = tamanhoTela;
            Processador = processador;
        }

        public double TamanhoTela { get; set; }
        public string Processador { get; set; }

        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            System.Console.WriteLine($"\nResolução: {TamanhoTela}\nCPU: {Processador}");
        }
    }
}