// See https://aka.ms/new-console-template for more information

using Petshop;

Dono dono = new("Gabriel", 20, "Rua Das Seriguelas");

Gato taylor = new("Taylor", "SDR", true, 5, dono);
Cachorro brutus = new("Brutus", "Poodle", false, 45, "Pequeno", dono);
List<Pet> pets = new List<Pet>();
pets.Add(taylor);
pets.Add(brutus);

foreach (var pet in pets)
{
    Console.WriteLine(pet);
}