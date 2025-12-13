
using System.Reflection;
using Gerenciamento_de_Produtos_Eletrônicos;

Celular pocket = new(200,1,"Pocket", "Samsung", "Fall5", 20000);
Celular j5 = new(400, 16, "Galaxy J5", "Samsung", "Fal5", 20000);

Notebook notebook = new(25, "Ryzen 5", "Nitro", "Acer", "ACC", 250);

Loja tecvideo = new Loja();

tecvideo.AdicionarProduto(pocket);
tecvideo.AdicionarProduto(j5);
tecvideo.AdicionarProduto(notebook);

tecvideo.ListarProdutos();
Thread.Sleep(1300);
Console.WriteLine(tecvideo.BuscarProdutoPorCodigo("ACC"));
Thread.Sleep(1300);


var busca = tecvideo.BuscarProdutoPorMarca(j5);
foreach (var item in busca)
{
    Console.WriteLine(item);
}

Thread.Sleep(1300);
Console.Clear();
tecvideo.AtualizarPreco("ACC", 21);
Thread.Sleep(1300);
tecvideo.RemoverProduto("ACC");
Thread.Sleep(1300);
tecvideo.ListarProdutos();
Thread.Sleep(1300);

