using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Gerenciamento_de_Produtos_Eletrônicos
{
    public abstract class Produto
    {
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public String Marca { get; set; }
        private double preco;
        public double Preco
        {
            get { return preco; }
            set {
                if (value < 0)
                    throw new ArgumentException("Um valor negativo não é válido!");
                preco = value; }
        }


        public Produto(string nome, string marca, string codigo, double preco)
        {
            Nome = nome;
            Marca = marca;
            Codigo = codigo;
            this.preco = preco;

        }

        public virtual void ExibirDetalhes()
        {
            System.Console.WriteLine($"Nome: {Nome}\nMarca: {Marca}\nPreço: {Preco}\nCódigo: {Codigo}");
        }
        public override string ToString()
        {
            return $"Nome: {Nome}\nMarca: {Marca}\nPreço: {Preco}\nCódigo: {Codigo}";
        }

    }
}