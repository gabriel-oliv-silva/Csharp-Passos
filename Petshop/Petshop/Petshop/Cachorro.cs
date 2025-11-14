namespace Petshop;

public class Cachorro : Pet
{
    public String Tamanho { get; set; }
    public Cachorro(string nome, String raca, bool vacinado, int idade, string tamanho, Dono dono)
    {
        Nome = nome;
        Raca = raca;
        Vacinado = vacinado;
        Idade = idade;
        Dono = dono;
        dono.Pets.Add(this);

        Tamanho = tamanho;
    }
}