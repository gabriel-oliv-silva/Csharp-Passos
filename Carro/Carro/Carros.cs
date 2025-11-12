using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carro
{
    public class Carros
    {
        public string Cor { get; set; }
        public string Modelo { get; set; }
        double velocidadeAtual;
        public double VelocidadeMaxima { get; set; }
        public bool ligado { get; set; } = false;


        public void Liga()
        {
            if (ligado)
            {
                ligado = false;
                System.Console.WriteLine("Carro desligado!");
            }
            else
            {
                ligado = true;
                System.Console.WriteLine("Carro ligado");

            }
        }
        public void Acelera(double velocidade)
        {
            if ((velocidadeAtual + velocidade) < VelocidadeMaxima)
                velocidadeAtual += velocidade;
            else
            {
                velocidadeAtual = VelocidadeMaxima;
                System.Console.WriteLine("Velocidade máxima atingida!");
            }
        }
        public int PassarMarcha()
        {
            if (velocidadeAtual <= 20)
                return 1;
            if (velocidadeAtual > 20 && velocidadeAtual <= 40)
                return 2;
            if (velocidadeAtual > 40 && velocidadeAtual <= 70)
                return 3;
            if (velocidadeAtual > 70 && velocidadeAtual <= 100)
                return 4;
            if (velocidadeAtual > 100)
                return 5;
            return 0;

        }

        public void Informacoes()
        {
            if (ligado)
                System.Console.WriteLine($"\nModelo: {Modelo}\nCor: {Cor}\nVelocidade máxima: {VelocidadeMaxima}Km/H\n\tLigado");
            else
                System.Console.WriteLine($"\nModelo: {Modelo}\nCor: {Cor}\nVelocidade máxima: {VelocidadeMaxima}Km/H\n\tDesligado");
        }
        public void Status()
        {

            if (ligado)
            {
                Console.WriteLine($"Velocímetro: {velocidadeAtual}Km/H");
            }
            else
                Console.WriteLine("Carro desligado!");

        }
    }
}