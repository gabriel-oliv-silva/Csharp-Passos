using System.Reflection.Metadata;

List<Artigo> repositorio = [
    new Artigo("O devorador de orgãoes", "IA", "SENAI", new Autor("Gabriel", "ogabriel@gmail.com")),
    new Artigo("O devorador de gente", "IA", "SENAI", new Autor("Gabriel", "ogabriel@gmail.com")),
    new Artigo("O matador de dragões", "Dragões", "SESI", new Autor("Pinoquio", "pinoquio@gmail.com")),
    new Artigo("Shaolin, O matador de dragões", "Dragões", "SESI", new Autor("Shaolin", "shaolinMatador de porco@gmail.com")),

    ];

foreach (var item in repositorio)
{
    if(item.Palavra_chave.Contains("Dragões"))
    Console.WriteLine(item);
    
}
    