using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Concessionária
{
    public class Acessorio
    {
        public Tipo TipoEnum { get; set; }
        public string Marca { get; set; }
        public string Material { get; set; }
        private double preco;
        public double Preco
        {
            get { return preco; }
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{value} não é um número válido para preço.");
                preco = value;
            }
        }

        public Acessorio(Tipo tipo, string marca, string material, double preco)
        {
            TipoEnum = tipo;
            Marca = marca;
            Material = material;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"\nTipo: {TipoEnum}\nMarca: {Marca}\nMaterial: {Material}\nPreço: {Preco}";
        }
    }
}