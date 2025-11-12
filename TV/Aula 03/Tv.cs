using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_03
{
    public class Tv
    {
        public int Volume { get; set; } = 0;
        public bool Ligar { get; set; } = false;
        public int Canal { get; set; } = 0;



        public void LigarTV()
        {

            if (Ligar == true)
            {
                Ligar = false;

            }
            else
                Ligar = true;
        }
        public void AumentarVolume()
        {
            if (Ligar)
            {
                if (Volume < 100)
                    this.Volume++;
                else
                    Console.WriteLine("Volume máximo atingido!");
            }
            else
            {
                System.Console.WriteLine("A televisão está desligada!");
            }
        }
        public void DiminuirVolume()
        {
            if (Ligar)
            {
                if (Volume > 0)
                    this.Volume--;
                else
                    Console.WriteLine("Volume mudo atingido");

            }


        }
        public void AumentarCanal()
        {
            if (Ligar)
            {

                if (Canal < 100)
                    this.Canal++;
                else
                    this.Canal = 0;

                Console.WriteLine($"Canal: {Canal}");

            }

        }
        public void DiminuirCanal()
        {
            if (Ligar)
            {
                if (Canal > 0)
                    this.Canal--;
                else
                    this.Canal = 100;

            }


        }
        public void TrocarCanalM(int canal)
        {
            if (Ligar)
            {
                if (this.Canal == canal)
                {
                    Console.WriteLine($"Você já está no canal {canal}");
                }

                else
                {
                    if (canal <= 100)
                    {
                        this.Canal = canal;
                        Console.WriteLine($"Canal: {this.Canal}");
                    }
                    else
                    {
                        System.Console.WriteLine($"{canal} não é um canal válido, escolha um entre 0 e 100!");
                    }
                }

            }

        }
        public void Status()
        {
            Console.WriteLine("\nSituação:");

            if (Ligar)
                Console.WriteLine($"\nVolume: {Volume}\nCanal: {Canal}\n");
            else
                System.Console.WriteLine("\nTevê desligada!\n");
        }
    }
}