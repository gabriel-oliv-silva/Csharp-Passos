using SENA_TEC;
double CalcularTotalPCs(List<Computador> computadors)
{
    double preco_total = 0;

    foreach (var item in computadors)
    {
        preco_total = item.CalcularValorTotal();
    }
    return preco_total;
}

Periferico mouse = new(TipoEnum.MOUSE, "HAVIT", "Plástico", 250);
Periferico gamepad = new(TipoEnum.GAMEPAD, "ninja", "Plástico", 2500);
Periferico monitor = new(TipoEnum.MONITOR, "asus", "Plástico", 150);
Periferico headset = new(TipoEnum.HEADSET, "HAVIT", "Plástico", 2560);
Periferico speaker = new(TipoEnum.SPEAKER, "MANCER", "Plástico", 300);

Computador pc = new("Mancer", "Low-end", "I3 2200", 3000);
Computador pc1 = new("Positivo", "high-end", "Ryzen 5 5600G", 7000);
Computador pc2 = new("Mancer", "mid-end", "I7 2600", 5000);
Computador pc3 = new("Mancer", "nsei-end", "Ryzen 9", 55000);

pc.AdicionarPeriferico(monitor);
pc.AdicionarPeriferico(headset);
pc2.AdicionarPeriferico(gamepad);
pc3.AdicionarPeriferico(speaker);
pc1.AdicionarPeriferico(mouse);
pc.RemoverPeriferico("havit");

List<Computador> computadores = [
    pc,
pc1,
pc2,
pc3,
];

Console.Clear();

pc.ExibirDetalhes();
pc.AplicarDesconto(10);

Console.WriteLine($"\nValor total de todos os computadores: R${CalcularTotalPCs(computadores)}");