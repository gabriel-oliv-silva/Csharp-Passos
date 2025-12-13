using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Gabriel_Oliveira_Silva___Avaliação
{
    public abstract class Animal
    {
        public string Nome { get; set; }
        public string Especie { get; set; }

        private int idade;
        public int Idade
        {
            get { return idade; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("A idade não pode ser negativa!");
                idade = value;
            }
        }
        private double precoBanho;

        public double PrecoBanho
        {
            get { return precoBanho; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("O preço do banho não pode ser negativo!");
                precoBanho = value;
            }
        }
        public Animal(string nome, string especie, int idade, double precoBanho)
        {
            Nome = nome;
            Especie = especie;
            Idade = idade;
            PrecoBanho = precoBanho;
        }
        public abstract void ExibirDetalhes();

        public override string ToString()
        {
            return $"\nNome: {Nome}\nEspecie: {Especie}\nIdade: {Idade} anos\nPreco do banho: R${PrecoBanho}";
        }



    }
}