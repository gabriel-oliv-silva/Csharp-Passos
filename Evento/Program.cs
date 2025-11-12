using Aula_04;
using System;

Evento evento = new Evento("Paredão do Cão", "Purgatório, Rua 6");

// Pergunta se o evento será pago
Console.Write("O evento será pago? (Sim/Não): ");
string decisao = Console.ReadLine()?.Trim() ?? "";

// Se for pago, pede o valor
if (decisao.Equals("Sim", StringComparison.OrdinalIgnoreCase))
{
    Console.Write("Decida o valor do evento: ");
    if (int.TryParse(Console.ReadLine(), out int valor))
        evento.Valor = valor;
    else
        Console.WriteLine("Valor inválido! Será considerado gratuito.");
}

// Pede número de pessoas
Console.Write("Quantas pessoas irão ao evento?: ");
if (!int.TryParse(Console.ReadLine(), out int quantidade))
{
    Console.WriteLine("Número inválido. Encerrando programa...");
    return;
}

// Cadastra as pessoas
for (int i = 0; i < quantidade; i++)
{
    Console.WriteLine($"\n--- Pessoa {i + 1} ---");

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Endereço: ");
    string endereco = Console.ReadLine();

    Console.Write("Idade: ");
    if (int.TryParse(Console.ReadLine(), out int idade))
    {
        Pessoas pessoa = new Pessoas(nome, endereco, idade);
        evento.Pessoas.Add(pessoa);
    }
    else
    {
        Console.WriteLine("Idade inválida! Pessoa não adicionada.");
        i--; // repete a iteração
    }
}

// Mostra todas as pessoas cadastradas
Console.WriteLine($"\nPessoas presentes no evento \"{evento.Nome}\":");

if (evento.Pessoas.Count == 0)
{
    Console.WriteLine("Nenhuma pessoa cadastrada.");
}
else
{
    foreach (var p in evento.Pessoas)
        Console.WriteLine($"- {p.Nome} ({p.Idade} anos)");
}
