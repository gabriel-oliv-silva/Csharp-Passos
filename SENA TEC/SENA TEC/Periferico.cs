using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SENA_TEC
{
    public class Periferico
    {
        public TipoEnum Tipo { get; set; }
        public String Marca { get; set; }
        public String Material { get; set; }
        private Double Preco;
        public Double Precos
        {
            get { return Preco; }
            set
            {
                if (value > 0) Preco = value;
                else
                    throw new ArgumentException("Valor inválido!");
            }
        }

        public Periferico(TipoEnum tipo, string marca, string material, double preco)
        {
            Tipo = tipo;
            Marca = marca;
            Material = material;
            Preco = preco;

        }
        public override string ToString()
        {
            return $"- Periférico -\n\nMarca: {Marca}\nMaterial: {Material}\nPreco: R${Preco}";
        }
    }
}