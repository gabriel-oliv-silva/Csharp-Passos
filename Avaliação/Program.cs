using System.Diagnostics;
using System.Net;
using Gabriel_Oliveira_Silva___Avaliação;

PetShop shop = new();
shop.AdicionarAnimal(new Cachorro("Rottweiler", PorteEnum.GRANDE,"Neo", "Cachorro", 2, 2000));
shop.AdicionarAnimal(new Cachorro("Poodle", PorteEnum.PEQUENO,"Gold", "Cachorro", 1, 400));
shop.AdicionarAnimal(new Gato(PelagemEnum.BRANCA, "Gelinho", "SDR", 2, 450));

shop.ListarAnimais();

Thread.Sleep(2000); // Dá uma pausa de 2 segundos na compilação.
Console.Clear(); // Limpa o terminal

var animalBuscado = shop.BuscarPorNome("Gold");
animalBuscado.ExibirDetalhes();

Thread.Sleep(2000);
Console.Clear();

shop.AtualizarPrecoBanho("Gold", 20);
shop.RemoverAnimal("Neo");
shop.ListarAnimais();

Thread.Sleep(2000);
Console.Clear();

shop.LimparLista();

Thread.Sleep(2000); 
Console.Clear();

shop.ListarAnimais();

