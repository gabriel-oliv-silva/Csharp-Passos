using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_de_Produtos_Eletrônicos
{
    public class Celular : Produto
    {
        public Celular(int capacidadeBateria, int memoriaInterna, string nome, string marca, string codigo, double preco) : base(nome, marca, codigo, preco)
        {
            CapacidadeBateria = capacidadeBateria;
            MemoriaInterna = memoriaInterna;
        }

        public int CapacidadeBateria { get; set; }
        public int MemoriaInterna { get; set; }

        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            System.Console.WriteLine($"\nCapacidade da bateria: {CapacidadeBateria}\nMemoria Interna: {MemoriaInterna}");
        }
    }
}