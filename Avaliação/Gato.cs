using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_Oliveira_Silva___Avaliação
{
    public class Gato : Animal
    {
        public PelagemEnum PelagemEnum { get; set; }
        public Gato(PelagemEnum corPelagem, string nome, string especie, int idade, double precoBanho) : base(nome, especie, idade, precoBanho)
        {
            PelagemEnum = corPelagem;
        }

        public override void ExibirDetalhes()
        {
            
            System.Console.WriteLine(ToString());
            System.Console.WriteLine($"\nCor da pelagem: {PelagemEnum}");

        }
    }
}