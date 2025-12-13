using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Gabriel_Oliveira_Silva___Avaliação
{
    public class Cachorro : Animal
    {
        public string Raca { get; set; }
        public PorteEnum PorteEnum { get; set; }
        public Cachorro(string raca, PorteEnum porte, string nome, string especie, int idade, double precoBanho) : base(nome, especie, idade, precoBanho)
        {
            Raca = raca;
            PorteEnum = porte;

        }

        public override void ExibirDetalhes()
        {
            System.Console.WriteLine(ToString()); 
            System.Console.WriteLine($"\nRaça: {Raca}\nPorte: {PorteEnum}");
        }
    }
}