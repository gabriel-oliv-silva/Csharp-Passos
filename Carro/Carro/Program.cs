using Carro;

Carros carro = new Carros();

System.Console.Write("Escolha um modelo para o seu carro: ");
carro.Modelo = Console.ReadLine();
System.Console.Write("Escolha uma cor para o seu carro: ");
carro.Cor = Console.ReadLine();

System.Console.Write("Decida uma velocidade máxima: ");
string max = Console.ReadLine();
do
{
    System.Console.Write("Valor inválido, decida um número real ou inteiro!\nTente novamente: ");
    max = Console.ReadLine();
}
while (!double.TryParse(max, out double result));

if (double.TryParse(max, out double resultado))
    carro.VelocidadeMaxima = resultado;

string opcao;
System.Console.WriteLine($"Opere o seu {carro.Modelo}:");
do
{
    System.Console.Write("1. Ligar\n2. Acelerar \n3. Passar Marcha\n4. Consultar informações do carro\n0. Sair\nEscolha uma opção: ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            carro.Liga();

            break;
        case "2":

            if (carro.ligado)
            {
                System.Console.Write("Insira o quanto você deseja acelerar: ");
                string valor = Console.ReadLine();
                do
                {

                    System.Console.Write("\nInsira um número real ou inteiro válido!\n Tente novamente:");
                    valor = Console.ReadLine();

                }
                while (!double.TryParse(valor.Trim(), out double resulta));

                if (double.TryParse(valor, out double acelerar))
                    carro.Acelera(acelerar);

            }
            break;
        case "3":

            if (carro.ligado)
                System.Console.WriteLine($"Marcha: {carro.PassarMarcha()}");

            break;

        case "4":
            carro.Informacoes();
            break;
        default:

            System.Console.WriteLine("Insira uma opção válida!");
            break;
    }

    carro.Status();

}
while (opcao != "0");