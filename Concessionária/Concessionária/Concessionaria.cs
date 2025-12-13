

using Concessionária;

void adicionarVeiculo(List<Veiculo> veiculos, Veiculo veiculo)
{
    veiculos.Add(veiculo);
}

void buscarPorMarca(List<Veiculo> veiculos ,string marca)
{
    int i = 0;
    foreach (var item in veiculos)
    {
        if (string.Equals(item.Marca, marca, StringComparison.OrdinalIgnoreCase))
        {
            i++;
            System.Console.WriteLine(item);
        }

    }
    if (i == 0)
        System.Console.WriteLine($"Nenhum veículo com a marca {marca} encontrado!");
}

void buscarPorPreco(List<Veiculo> veiculos, double preco)
{
    int i = 0;
    foreach (var item in veiculos)
    {
        if (item.CalcularValorTotal() <= preco)
        {
            i++;
            Console.WriteLine(item);
        }

    }
    if(i == 0)
    System.Console.WriteLine($"Nenhum veículo com o preço menor ou igual a {preco} encontrado!");
}
void ExibirDetalhesConcenssionária(List<Veiculo> veiculos)
{
    foreach (var item in veiculos)
    {
        item.ExibirDetalhes();
    }
}

Acessorio tapete = new(Tipo.TAPETE, "BYD", "Ferro", 210);
Acessorio rodas = new(Tipo.RODAS, "BYD", "Ferro", 2210);
Acessorio banco = new(Tipo.BANCO_COLEO, "BYD", "Ferro", 2106);
Acessorio cambio = new(Tipo.CAMBIO_AUTOMATICO, "BYD", "Ferro", 280);

Veiculo b12 = new("Volvo", "B12", 2012, 4500);
Veiculo b11 = new("Volvo", "B11", 2011, 3500);
Veiculo b10 = new("Volvo", "B10", 2010, 2500);
Veiculo b09 = new("Volvo", "B09", 2009, 1500);
Veiculo b08 = new("Volvo", "B08", 2008, 500);
Veiculo m1133 = new("Mercedes", "1133", 2000, 50000);
Veiculo veiculo = new("BYD", "Voltz", 2025, 54000);

b12.AdicionarAcessorio(cambio);
b11.AdicionarAcessorio(rodas);
b10.AdicionarAcessorio(banco);
b09.AdicionarAcessorio(tapete);
b08.AdicionarAcessorio(cambio);
m1133.AdicionarAcessorio(rodas);
m1133.AplicarDesconto(50);
veiculo.AdicionarAcessorio(tapete);

List<Veiculo> veiculos = new([
b12, b11, b09, b08, m1133, veiculo
]);

Console.Clear();

buscarPorMarca(veiculos, "Mercedes");
buscarPorPreco(veiculos, 500);

ExibirDetalhesConcenssionária(veiculos);
