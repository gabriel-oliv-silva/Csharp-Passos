namespace Petshop;

public class Dono
{
    public String Nome { get; set; }
    public int Idade { get; set; }
    public string Endereço { get; set; }
    public List<Pet> Pets { get; set; }

    public Dono(String nome, int idade, string endereço)
    {
        Nome = nome;
        Idade = idade;
        Endereço = endereço;
        Pets = new List<Pet>();
    }

    public override string ToString()
    {
        if (Pets.Count > 1)
            return $"\n\t- Tutor -\n\nNome: {Nome}\nIdade: {Idade}\nEndereço: {Endereço}\nPets: {Pets.Count} animais";
        return $"\n\t- Tutor -\n\nNome: {Nome}\nIdade: {Idade}\nEndereço: {Endereço}\nPets: {Pets.Count} animal";
    }
}