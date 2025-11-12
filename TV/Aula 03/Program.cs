
using Aula_03;

Tv tv = new Tv();

string opcao;

do
{

    System.Console.Write("1. Power\n2. Passar Canal\n3. Voltar Canal\n4. Escolher canal\n5. Aumentar volume\n6. Diminuir volume\n0. Sair\nEscolha uma opção:");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            tv.LigarTV();

            break;
        case "2":

            tv.AumentarCanal();

            break;
        case "3":

            tv.DiminuirCanal();

            break;
        case "4":

            int result;

            System.Console.Write("Escolha um canal a ser passado entre 0 e 100: ");
            var canal = Console.ReadLine();
            if (Int32.TryParse(canal, out result))
            {
                tv.TrocarCanalM(result);
            }
            else
                System.Console.WriteLine("Insira um número válido!");
            break;
        case "5":

            tv.AumentarVolume();

            break;
        case "6":
            tv.DiminuirVolume();
            break;
        default:
            System.Console.WriteLine("Escolhaa uma opção válida!");
            break;
    }
    tv.Status();

}
while (opcao != "0");